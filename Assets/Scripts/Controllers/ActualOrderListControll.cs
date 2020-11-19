using System;
using System.Collections.Generic;
using UnityEngine;

public class ActualOrderListControll : MonoBehaviour
{
    [SerializeField] private SetOrders orders;
    [SerializeField] private Final final;
    [SerializeField] private LevelDataControll levelControll;

    public void DeleteOrder(string id, GameObject thisGameObject, bool complete)
    {
        if (!complete)
        {
            levelControll.Add("failed", LevelData.OrderUnCheck += 1);
        }
        for(int i = 0; i < orders.actualOrderList.Count; i++)
        {
            if(orders.actualOrderList[i].id == Convert.ToInt32(id))
            {
                orders.actualOrderList.Remove(orders.actualOrderList[i]);
                break;
            }
        }
        thisGameObject.SetActive(false);
        final.FinalControll();
    }
}
