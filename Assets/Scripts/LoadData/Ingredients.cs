using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ingredients : MonoBehaviour
{
    public static IngredientsItem[] ingredients;
    [SerializeField] private UnityEvent m_IngredientsEvent;
    [SerializeField] private int numberOfItems;

    void Start()
    {
        TextAsset temp = Resources.Load<TextAsset>("Ingredients");
        string json = JsonHelper.fixJson(temp.text);
        ingredients = JsonHelper.FromJson<IngredientsItem>(json);
        for (int i = 0; i < ingredients.Length; i++)
            ingredients[i].count = numberOfItems;
        if (m_IngredientsEvent == null) m_IngredientsEvent = new UnityEvent();
        if (ingredients.Length != 0) m_IngredientsEvent.Invoke();
    }
}

[Serializable]
public class IngredientsItem
{
    public int _id, count;
    public string name, code, type, typeCode;
}