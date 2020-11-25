using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Button plus, minus;
    [SerializeField] private GameObject fromBuscket, toBuscket;
    [SerializeField] private Text costPerOne, code, currentPrice;
    public void Awake()
    {
        currentPrice = GameObject.FindGameObjectWithTag("StorePanel_Cost").GetComponent<Text>();
    }

    public void Plus()
    {
        inputField.text = (Convert.ToInt32(inputField.text) + 1).ToString();
    } 
    public void Minus()
    {
        if (Convert.ToInt32(inputField.text) != 0)
            inputField.text = (Convert.ToInt32(inputField.text) - 1).ToString();
    }
    
    public void ToBuscket()
    {
            StoreData.CurrentPrice += Convert.ToInt32(costPerOne.text.Replace("$", "")) * Convert.ToInt32(inputField.text);
            StoreData.buscket.Add(code.text, Convert.ToInt32(inputField.text));
            inputField.enabled = false;
            plus.enabled = false;
            minus.enabled = false;
            print(StoreData.CurrentPrice);
        currentPrice.text = StoreData.CurrentPrice.ToString();
        toBuscket.SetActive(false);
        fromBuscket.SetActive(true);
    }
    
    public void FromBuscket()
    {
            inputField.enabled = true;
            plus.enabled = true;
            minus.enabled = true;
            StoreData.buscket.Remove(code.text);
            StoreData.CurrentPrice -= Convert.ToInt32(costPerOne.text.Replace("$", "")) * Convert.ToInt32(inputField.text);
            print(StoreData.CurrentPrice);
        inputField.text = 0.ToString();
        currentPrice.text = StoreData.CurrentPrice.ToString();
        fromBuscket.SetActive(false);
        toBuscket.SetActive(true);
    }
}
