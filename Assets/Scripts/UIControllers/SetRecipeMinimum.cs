using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRecipeMinimum : MonoBehaviour
{
    /*Контент рецепта*/
    [SerializeField] private RectTransform recipeIngredientsContent;
    /*Префаб ингридента рецепта*/
    [SerializeField] private RectTransform recipeIngredientsPrefab;
    [SerializeField] private Recipes recipes;



    public void SetRecipeIngredientsList()
    {
        foreach (Transform child in recipeIngredientsContent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < recipes.recipes.Length; i++)
        {
            if (recipes.recipes[i].code.Equals(LevelData.RecipeCode))
            {
                for (int item = 0; item < recipes.recipes[i].ingredients.Length; item++)
                {
                    var instance = Instantiate(recipeIngredientsPrefab.gameObject);
                    instance.transform.SetParent(recipeIngredientsContent, false);
                    InitializeResourceItemView(instance, recipes.recipes[i].ingredients[item], item);
                }
                break;
            }
        }
    }
    public void InitializeResourceItemView(GameObject viewGameObject, RecipeIngredients ingridient, int index)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.ingridientCount.text = "x" + ingridient.count.ToString();
        view.icon.sprite = Resources.Load<Sprite>("Ingridients/" + LevelData.LevelCode + "/" + ingridient.nameCode + "_UI");
    }

    public class ResourcePrefabComponents
    {
        public Text ingridientCount;
        public Image icon;

        public ResourcePrefabComponents(Transform rootView)
        {
            icon = rootView.Find("Icon").GetComponent<Image>();
            ingridientCount = rootView.Find("Count").GetComponent<Text>();
        }
    }
}
