using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRecipesIngridients : MonoBehaviour
{
    /*Контент рецепта*/
    [SerializeField] private RectTransform recipeIngredientsContent;
    /*Префаб ингридента рецепта*/
    [SerializeField] private RectTransform recipeIngredientsPrefab;
    [SerializeField] private Recipes recipes;
    [SerializeField] private Text title;



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
                title.text = recipes.recipes[i].name;
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
        view.numberIngridient.text = (++index).ToString() + ")";
        view.ingridientCount.text = "x" + ingridient.count.ToString();
        view.ingridientName.text = ingridient.type;
        view.icon.sprite = Resources.Load<Sprite>("Ingridients/" + LevelData.LevelCode + "/" + ingridient.nameCode + "_UI");
    }

    public class ResourcePrefabComponents
    {
        public Text numberIngridient, ingridientCount, ingridientName;
        public Image icon;

        public ResourcePrefabComponents(Transform rootView)
        {
            icon = rootView.Find("IngridientsIcon").GetComponent<Image>();
            numberIngridient = rootView.Find("NumberIngridient").GetComponent<Text>();
            ingridientName = rootView.Find("NameIngridient").GetComponent<Text>();
            ingridientCount = rootView.Find("IngridientCount").GetComponent<Text>();
        }
    }

}
