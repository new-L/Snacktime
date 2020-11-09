using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDishWithOrder : MonoBehaviour
{
    [SerializeField] private SetOrders orders;
    [SerializeField] private Final final;
    [SerializeField] private TableAreaData dish;
    [SerializeField] private List<CurrentDish> currentDishes;
    [SerializeField] public LevelDataControll levelDataControll;
    [SerializeField] public Transform tableArea;
    public List<GameObject> prefabs;
    private bool _complete;
    //ЗАГАВНОКОЖЕНО ПО САМЫЕ ЯЙЦА
    public void CheckOrder()
    {
        _complete = false;
        currentDishes.Clear();
        foreach (var item in orders.actualOrderList)
        {
            currentDishes.Clear();
            foreach (var model in item.ingredients)
            {
                if (model.setable)
                    currentDishes.Add(new CurrentDish(model.nameCode, "", model.count));
            }
            if(CheckIngridients())//Если находим в списке активных заказов наше приготовленное блюдо
            {
                for(int i = 0; i < prefabs.Count; i++)
                {
                    Text text = prefabs[i].transform.Find("OrderID").GetComponent<Text>();
                    if(text.text.Equals(item.id.ToString()))
                        prefabs[i].SetActive(false);
                }
                _complete = true;//Обновляем инфо-панель
                levelDataControll.Add("money", LevelData.Money += item.money);
                levelDataControll.Add("complete", LevelData.OrderCheck += 1);
                orders.actualOrderList.Remove(item);
                print("С чем-то совпало");
                break;
            }
        }
        if (!_complete)
            levelDataControll.Add("failed", LevelData.OrderUnCheck += 1);

        foreach (Transform child in tableArea)
        {
            Destroy(child.gameObject);
        }
        dish.dish.Clear();
        final.FinalControll();
    }

        


    private bool CheckIngridients()
    {
        if (dish.dish.Count == currentDishes.Count)
        {
            foreach (var item in dish.dish)
            {
                foreach (var model in currentDishes)
                {
                    if (model.code.Equals(item.code) && model.count == item.count)
                    {
                        model.checkable = true;//всё(в том числе и количество ингредиентов) совпало
                    }
                }
            }
        }
        else//Мало ингридиентов
        {
            print("Мало ингридиентов");
            return false;
        }

        foreach (var item in currentDishes)
        {
            if (!item.checkable)
            {
                return false;
            }
        }

        return true;

    }

}
