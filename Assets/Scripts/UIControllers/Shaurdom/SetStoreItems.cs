using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStoreItems : MonoBehaviour
{
    /*Контент ресурсов*/
    [SerializeField] private RectTransform m_ItemContent;
    /*Префаб ресурсов персонажа*/
    [SerializeField] private RectTransform m_ItemPrefab;



    /*Вывод данных о ингредиентах*/
    public void SetStoreIngredients()
    {
        foreach (Transform child in m_ItemContent)
        {
            Destroy(child.gameObject);
        }
        foreach (var model in Ingredients.ingredients)
        {
            if (!model.code.Contains("_ready]"))
            {
                var instance = GameObject.Instantiate(m_ItemPrefab.gameObject) as GameObject;
                instance.transform.SetParent(m_ItemContent, false);
                InitializeResourceItemView(instance, model);
            }
        }
    }
    public void InitializeResourceItemView(GameObject viewGameObject, IngredientsItem ingredients)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.ingredientName.text = ingredients.name;
        view.ingredientCost.text = ingredients.cost.ToString() + "$";
        view.code.text = ingredients.typeCode;
        view.icon.sprite = Resources.Load<Sprite>("Ingridients/" + ingredients.code + "_UI");
    }

    public class ResourcePrefabComponents
    {
        public Text ingredientName, ingredientCost, count, code;
        public Image icon;

        public ResourcePrefabComponents(Transform rootView)
        {
            ingredientName = rootView.Find("Name").GetComponent<Text>();
            code = rootView.Find("Code").GetComponent<Text>();
            ingredientCost = rootView.Find("CostPerOne").GetComponent<Text>();
            icon = rootView.Find("Icon").GetComponent<Image>();
        }
    }
}
