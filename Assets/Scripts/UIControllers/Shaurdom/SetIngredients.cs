using UnityEngine;
using UnityEngine.UI;

public class SetIngredients : MonoBehaviour
{
    /*Контент ресурсов*/
    [SerializeField] private RectTransform ingredientsContent;
    /*Префаб ресурсов персонажа*/
    [SerializeField] private RectTransform ingredientsPrefab;
    /*Ресуры игрока*/
    [SerializeField] private Ingredients ingredients;


    /*Вывод данных о ингредиентах*/
    public void SetIngredientsList(string typeCode)
    {
        foreach (Transform child in ingredientsContent)
        {
            Destroy(child.gameObject);
        }
        foreach (var model in ingredients.ingredients)
        {
            if (model.typeCode.Equals(typeCode))
            {
                var instance = Instantiate(ingredientsPrefab.gameObject);
                instance.transform.SetParent(ingredientsContent, false);
                InitializeResourceItemView(instance, model);
            }
        }
    }
    public void InitializeResourceItemView(GameObject viewGameObject, IngredientsItem ingredients)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.ingredientName.text = ingredients.name;
        view.ingredientsCode.text = ingredients.code;
    }

    public class ResourcePrefabComponents
    {
        public Text ingredientName, ingredientsCode;

        public ResourcePrefabComponents(Transform rootView)
        {
            ingredientName = rootView.Find("Ingredients_Name").GetComponent<Text>();
            ingredientsCode = rootView.Find("Code").GetComponent<Text>();
        }
    }
}
