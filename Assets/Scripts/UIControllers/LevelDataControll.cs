using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDataControll : MonoBehaviour
{
    [SerializeField]
    private Text
        money,
        orderCheck,
        orderUnCheck;
    private void Start()
    {
        SetText(money, LevelData.Money = 0);
        SetText(orderCheck, LevelData.OrderCheck = 0);
        SetText(orderUnCheck, LevelData.OrderUnCheck = 0);
    }

    public void Add(string type, int info)
    {
        switch (type)
        {
            case "money": SetText(money, info); break;
            case "complete": SetText(orderCheck, info); break;
            case "failed": SetText(orderUnCheck, info); break;
        }
    }

    public void SetText(Text item, int value)
    {
        item.text = value.ToString();
    }
}
