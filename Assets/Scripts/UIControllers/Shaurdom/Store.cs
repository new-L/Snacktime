using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private int timer;
    [SerializeField] private Text storeTimer, currentPrice, levelMoney;
    [SerializeField] private Button storeButton;
    [SerializeField] private LevelDataControll dataControll;

    private void Start()
    {
        storeTimer.text = "";
    }
    public void Pay()
    {
        if(StoreData.CurrentPrice <= LevelData.Money && StoreData.CurrentPrice > 0)
        {
            LevelData.Money -= StoreData.CurrentPrice;
            StoreData.CurrentPrice = 0;
            currentPrice.text = StoreData.CurrentPrice.ToString();
            storeButton.enabled = false;
            storeTimer.text = timer.ToString();
            dataControll.SetText(levelMoney, LevelData.Money);
            InvokeRepeating("StoreTimer", 0f, 1.1f);
        }
    }

    public void StoreTimer()
    {
        storeTimer.text = timer.ToString();
        if (timer <= 0) 
        { 
            IngridientsUpdate(); 
            storeTimer.text = ""; 
            StoreData.buscket.Clear();
            storeButton.enabled = true;
            CancelInvoke(); 
        }
        timer--;
    }

    public void IngridientsUpdate()
    {
        foreach(var code in StoreData.buscket)
        {
            foreach(var item in Ingredients.ingredients)
            {
                if(code.Key.Equals(item.code))
                {
                    item.count += code.Value;
                    break;
                }
            }
        }
    }
}
