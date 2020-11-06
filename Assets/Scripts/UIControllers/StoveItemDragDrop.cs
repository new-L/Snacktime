using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoveItemDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform _objectTransform;
    [SerializeField] private RectTransform _screen;
    [SerializeField] private RectTransform _defaultParent;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Canvas _canvas;
    public static bool dropedOnTable;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!StoveData.ReadyToDrag)
            print(StoveData.Code);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (StoveData.ReadyToDrag)
        {
            dropedOnTable = false;
            TableAreaData.Code = StoveData.Code;
            transform.SetParent(_screen, true);
            _canvasGroup.alpha = .6f;
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (StoveData.ReadyToDrag)
        {
            _objectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (StoveData.ReadyToDrag)
        {
            transform.SetParent(_defaultParent);
            _objectTransform.anchoredPosition = _defaultParent.anchoredPosition;
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
            if (dropedOnTable)
            {
                gameObject.SetActive(false);
                StoveData.Blocked = false;
                StoveData.Code = "";
            }
        }
    }
}
