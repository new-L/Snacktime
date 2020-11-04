using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class GetName : MonoBehaviour
{

    public static string CodeToName(IngredientsItem[] list , string code)
    {
        for(int i = 0; i < list.Length; i++)
        {
            if (list[i].code.Equals(code))
                return list[i].name;
        }
        return "";
    }
    
    public static string CodeToName(RecipesItem[] list ,string code)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].code.Equals(code))
                return list[i].name;
        }
        return "";
    }
}
