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

    public void SetText(Text item, int value)
    {
        item.text = value.ToString();
    }
}
