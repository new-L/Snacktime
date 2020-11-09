using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    [SerializeField] private Order order;
    [SerializeField] private SetOrders orders;
    [SerializeField] private OpenMenu _menus;
    [SerializeField] private GameObject _PausePanel, _FinalPanel;

    [SerializeField]
    private Text
        _title,
        _completeTask,
        _failedTask,
        _money;
    [SerializeField] private Image _background;

    [SerializeField] private int precent;
    bool isPaused = true;
    public void PauseTheGame()
    {
        //if(isPaused)
        //{
        //    Time.timeScale = 1;
        //    isPaused = false;
        //}
        //else
        //{
        Time.timeScale = 0;
        isPaused = true;
        _menus.OpenPanel(_PausePanel);
        _menus.OpenPanel(_FinalPanel);
        //}
    }

    public void FinalControll()
    {
        if(order.orderItem.Count == 0 && orders.actualOrderList.Count == 0)
        {
            PauseTheGame();
            _completeTask.text = LevelData.OrderCheck.ToString();
            _failedTask.text = LevelData.OrderUnCheck.ToString();
            _money.text = LevelData.Money.ToString();
            if (CheckWin() < precent)
            {
                _title.text = "Ты победил!";
                _background.sprite = Resources.Load<Sprite>("FinalPanelWin");
            }
            else
            {
                _title.text = "Ты проиграл!";
                _background.sprite = Resources.Load<Sprite>("FinalPanelLose");
            }
            
        }
    }

    private float CheckWin()
    {
        return (LevelData.OrderUnCheck / order.orderCount) * 100;
    }
}
