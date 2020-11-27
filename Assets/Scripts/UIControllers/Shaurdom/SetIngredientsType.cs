using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetIngredientsType : MonoBehaviour
{
    /*Контент ресурсов*/
    [SerializeField] private RectTransform m_TypeContent;
    /*Префаб ресурсов персонажа*/
    [SerializeField] private RectTransform m_TypePrefab;
    [SerializeField] private List<string> m_OriginalType;



    /*Вывод данных о ингредиентах*/
    public void SetIngredientsTypeList()
    {
        foreach (Transform child in m_TypeContent)
        {
            Destroy(child.gameObject);
        }
        foreach (var model in Ingredients.ingredients)
        { 
            if (!m_OriginalType.Contains(model.type))
            {
                m_OriginalType.Add(model.type);
                var instance = Instantiate(m_TypePrefab.gameObject);
                instance.transform.SetParent(m_TypeContent, false);
                InitializeResourceItemView(instance, model);
            }
        }
    }
    public void InitializeResourceItemView(GameObject viewGameObject, IngredientsItem ingredients)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.ingredientType.text = ingredients.type;
        view.ingredientsCode.text = ingredients.typeCode;
        view.type.sprite = Resources.Load<Sprite>("Types/" + ingredients.typeCode);
    }

    public class ResourcePrefabComponents
    {
        public Text ingredientType, ingredientsCode;
        public Image type;

        public ResourcePrefabComponents(Transform rootView)
        {
            ingredientType = rootView.Find("TypeIngredient").GetComponent<Text>();
            ingredientsCode = rootView.Find("TypeCode").GetComponent<Text>();
            type = rootView.Find("TypeIngredientIco").GetComponent<Image>();
        }
    }
}
