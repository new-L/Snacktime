using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeItemStatement : MonoBehaviour
{
    private OpenMenu openMenu;
    private SetRecipesIngridients setIngridients;
    private Text code;

    void Awake()
    {
        openMenu = FindObjectOfType<OpenMenu>();
        setIngridients = FindObjectOfType<SetRecipesIngridients>();
        code = gameObject.transform.Find("Code").GetComponent<Text>();
    }

    public void OpenRecipeDetails()
    {
        LevelData.RecipeCode = code.text;
        setIngridients.SetRecipeIngredientsList();
        openMenu.OpenPanel("RecipeDetailPanel");
    }
}
