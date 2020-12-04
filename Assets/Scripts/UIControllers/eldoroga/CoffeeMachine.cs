using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField] private GameObject additional;
    [SerializeField] private Image additioanalItem;
    [SerializeField] private Text timerText;
    [SerializeField] private int timer;
    private void Start()
    {
        additional.SetActive(false);
        timerText.text = "";
    }
    public void Work() 
    {
        InvokeRepeating("TimerCM", 0f, 1.17f);
    }

    private void TimerCM()
    {
        timer--;
        timerText.text = timer.ToString();
        if (timer <= 0)
        {
            CoffeData.IsCoffee = true;
            additional.SetActive(true);
            additioanalItem.sprite = Resources.Load<Sprite>("Ingridients/" + LevelData.LevelCode + "/Real[coffee]");
            timerText.text = "";
            timer = 10;
            CancelInvoke("TimerCM");
        }        
    }


}
