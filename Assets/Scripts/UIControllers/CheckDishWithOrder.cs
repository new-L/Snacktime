using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDishWithOrder : MonoBehaviour
{
    [SerializeField] private SetOrders orders;
    [SerializeField] private TableAreaData dish;
    [SerializeField] private bool currentOrder;
    [SerializeField] private List<CurrentDish> currentDishes;
    [SerializeField] public  List<GameObject> prefabs;
    //ЗАГАВНОКОЖЕНО ПО САМЫЕ ЯЙЦА
    public void CheckOrder()
    {

        print("______________________________");
        currentOrder = true;
        currentDishes.Clear();
        foreach (var item in orders.actualOrderList)
        {
            currentDishes.Clear();
            print(item.name);
            foreach (var model in item.ingredients)
            {
                if (model.setable)
                    currentDishes.Add(new CurrentDish(model.nameCode, "", model.count));
            }
            if(CheckIngridients())
            {
                for(int i = 0; i < prefabs.Count; i++)
                {
                    Text text = prefabs[i].transform.Find("OrderID").GetComponent<Text>();
                    if(text.text.Equals(item.id.ToString()))
                        prefabs[i].SetActive(false);
                }
                orders.actualOrderList.Remove(item);
                print("С чем-то совпало");
                break;
            }
            print("______________________________");
        }
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
                        model.checkable = true;
                    }
                }
            }
        }
        else
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
