using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRecipes : MonoBehaviour
{

    /*Контент ресурсов*/
    [SerializeField] private RectTransform resourceContent;
    /*Префаб ресурсов персонажа*/
    [SerializeField] private RectTransform resPrefab;
    /*Ресуры игрока*/
    [SerializeField] private Recipes recipes;



    /*Вывод данных о рецептах*/
    public void SetRecipesList()
    {
        foreach (Transform child in resourceContent)
        {
            Destroy(child.gameObject);
        }
        foreach (var model in recipes.recipes)
        {
            var instance = GameObject.Instantiate(resPrefab.gameObject) as GameObject;
            instance.transform.SetParent(resourceContent, false);
            InitializeResourceItemView(instance, model);
        }
    }
    void InitializeResourceItemView(GameObject viewGameObject, RecipesItem recipes)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.recipeName.text = recipes.name;
        view.cookingTime.text = "~" + recipes.cookingtime.ToString() + " сек.";
    }

    public class ResourcePrefabComponents
    {
        public Text recipeName, cookingTime;

        public ResourcePrefabComponents(Transform rootView)
        {
            recipeName = rootView.Find("DishTitle").GetComponent<Text>();
            cookingTime = rootView.Find("CookingTime").GetComponent<Text>();
        }
    }

}
