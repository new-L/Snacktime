using System.Collections;
using System;
using UnityEngine;

public class AddIngredients : MonoBehaviour
{
    public Additional[] addIngr;
    void Start()
    {
        TextAsset temp = Resources.Load<TextAsset>("Data/" + LevelData.LevelCode + "/AddIngredients");
        string json = JsonHelper.fixJson(temp.text);
        addIngr = JsonHelper.FromJson<Additional>(json);
    }
}
/*Класс для декода json файла и хранения данных о рецептах игрока*/
[Serializable]
public class Additional
{
    public string name, code;
}