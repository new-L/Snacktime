using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoveData : MonoBehaviour, IDropHandler
{
    [SerializeField] private LevelDataControll _levelControll;
    [SerializeField] private Text timer;
    [SerializeField] private Image ingredientsImage;
    [SerializeField] private GameObject ingredients;

    private string _readyIngridientsPath;

    private static string _code;
    private static bool _blocked;
    private static bool _readyToDrag;

    private static int _timer;

    public static string Code { get => _code; set => _code = value; }
    public static bool Blocked { get => _blocked; set => _blocked = value; }
    public static bool ReadyToDrag { get => _readyToDrag; set => _readyToDrag = value; }

    public void StartCooking(int timer)
    {
        Blocked = true;
        _timer = timer;
        ReadyToDrag = false;
        InvokeRepeating("StoveTimer", 0f, 1.2f);
        
    }

    public void StopCooking()
    {
        ingredientsImage.sprite = Resources.Load<Sprite>(_readyIngridientsPath);
        SetImageNativeSize(ingredientsImage);
        Code = CodeToReady();
        ReadyToDrag = true;
        print("Ready");
    }

    private void StoveTimer()
    {
        if (_timer <= 0) { _timer = 0; StopCooking(); CancelInvoke("StoveTimer"); }
        _levelControll.SetText(timer, _timer--);
    }

    public void OnDrop(PointerEventData eventData)
    {        
        if(eventData.pointerDrag != null && !Blocked)
        {
            _readyIngridientsPath = "Ingridients/Real" + CodeToReady();
            if (Resources.Load<Sprite>(_readyIngridientsPath) != null)
            {
                ingredients.SetActive(true);
                ingredientsImage.sprite = Resources.Load<Sprite>("Ingridients/Real" + Code);
                SetImageNativeSize(ingredientsImage);
                StartCooking(10);
            }
        }
        
    }


    private string CodeToReady()
    {
        return Code.Insert(Code.Length - 1, "_ready");
    }

    private void SetImageNativeSize(Image image)
    {
        float aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
        var fitter = image.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;
    }
}
