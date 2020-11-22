using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public void Plus()
    {
        inputField.text = (Convert.ToInt32(inputField.text) + 1).ToString();
    } 
    public void Minus()
    {
        if (Convert.ToInt32(inputField.text) != 0)
            inputField.text = (Convert.ToInt32(inputField.text) - 1).ToString();
    }
}
