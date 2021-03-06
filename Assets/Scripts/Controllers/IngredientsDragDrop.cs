﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IngredientsDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private RectTransform screen, defaultParent;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public Text code, id;
    private int _currentIngridients;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultParent = GameObject.FindGameObjectWithTag("IngredientsContent").GetComponent<RectTransform>();
        screen = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _currentIngridients = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!StoveData.Blocked)
            StoveData.Code = code.text;
        TableAreaData.Code = code.text;
        transform.SetParent(screen, true);
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        print(code.text);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent);
        transform.SetSiblingIndex(_currentIngridients);
        canvasGroup.alpha = 1f;
        for(int i = 0; i < Ingredients.ingredients.Length; i++)
            if(Ingredients.ingredients[i].code.Equals(code.text) && Ingredients.ingredients[i].count > 0)
                canvasGroup.blocksRaycasts = true;
        print(code.text);
    }
}
