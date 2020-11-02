using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTimer : MonoBehaviour
{
    [SerializeField] private int timer;
    [SerializeField] private Text timerText, id;
    [SerializeField] private TimerConverter converter;
    [SerializeField] private OpenMenu openMenu;
    private OrderDetail orderDetail;

    void Start()
    {
        orderDetail = FindObjectOfType<OrderDetail>();
        openMenu = FindObjectOfType<OpenMenu>();
        converter = FindObjectOfType<TimerConverter>();
        timer = Convert.ToInt32(timerText.text);
        timerText.text = converter.Convert(timer);
        InvokeRepeating("Timer", .05f, 1.25f);
    }

    private void Timer()
    {
        timerText.text = converter.Convert(timer);
        timer--;
        if (timer < 0)
        {
            timerText.text = "0";
            CancelInvoke("Timer");
        }
    }

    public void OpenPanel()
    {
        LevelData.OrderID = Convert.ToInt32(id.text);
        openMenu.OpenPanel("OrderDetail");
        orderDetail.SetOrderDetail();
    }
}
