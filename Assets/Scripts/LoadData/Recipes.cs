using System;
using System.Collections.Generic;
using UnityEngine;

public class Recipes : MonoBehaviour
{
    public RecipesItem[] recipes;
    void Start()
    {
        TextAsset temp = Resources.Load<TextAsset>("Recipes");
        string json = JsonHelper.fixJson(temp.text);
        recipes = JsonHelper.FromJson<RecipesItem>(json);
    }
}
/*Класс для декода json файла и хранения данных о рецептах игрока*/
[Serializable]
public class RecipesItem
{
    public string name;
    public RecipeIngredients[] ingredients;
    public int cookingtime;
    public int money;
}

[Serializable]
public class RecipeIngredients
{
    public string type;
    public int count;
}
