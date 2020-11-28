using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    [SerializeField] private Order order;
    [SerializeField] private SetOrders orders;
    [SerializeField] private OpenMenu _menus;
    [SerializeField] private GameObject _PausePanel, _FinalPanel;
    [SerializeField] private LoadLevelData loadData;

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
        Time.timeScale = 0;
        isPaused = true;
        _menus.OpenPanel(_PausePanel);
        _menus.OpenPanel(_FinalPanel);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        isPaused = false;
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
                loadData.Load();
                for (int i = 0; i < loadData.levels.Length; i++)
                {
                    if(loadData.levels[i].code.Equals(LevelData.LevelCode))
                    {
                        loadData.levels[i + 1].locked = "unlocked";
                        break;
                    }
                }
                loadData.Save();
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


    public void Again()
    {
        UnPause();
        StaticVarToNull();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        UnPause();
        StaticVarToNull();
        SceneManager.LoadScene("LevelMenu");
    }


    private void StaticVarToNull()
    {
        LevelData.Money = 0;
        LevelData.OrderCheck = 0;
        LevelData.OrderUnCheck = 0;
        LevelData.OrderID = 0;
        LevelData.CurrentNoteType = string.Empty;
        LevelData.RecipeCode = string.Empty;

        StoreData.CurrentPrice = 0;
        StoreData.buscket.Clear();

        StoveData.Blocked = false;
        StoveData.ReadyToDrag = true;
        StoveData.Code = string.Empty;
        StoveData.Timer = 0;

        TableAreaData.Code = string.Empty;

        Ingredients.ingredients = null;
    }
}
