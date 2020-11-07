using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Recipes : MonoBehaviour
{
    public RecipesItem[] recipes;
    [SerializeField] private UnityEvent m_RecipesEvent;
    void Start()
    {
        TextAsset temp = Resources.Load<TextAsset>("Recipes");
        string json = JsonHelper.fixJson(temp.text);
        recipes = JsonHelper.FromJson<RecipesItem>(json);

        if (m_RecipesEvent == null) m_RecipesEvent = new UnityEvent();
        if (recipes.Length != 0) m_RecipesEvent.Invoke();

    }
}
/*Класс для декода json файла и хранения данных о рецептах игрока*/
[Serializable]
public class RecipesItem
{
    public string name, code;
    public RecipeIngredients[] ingredients;
    public int cookingtime;
    public int money;
}

[Serializable]
public class RecipeIngredients
{
    public string 
        type,
        nameCode,
        typeCode,
        refuse;
    public int count;
}
