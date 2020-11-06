using UnityEngine;
using UnityEngine.UI;

public class SetIngredients : MonoBehaviour
{
    /*Контент ресурсов*/
    [SerializeField] private RectTransform ingredientsContent;
    /*Префаб ресурсов персонажа*/
    [SerializeField] private RectTransform ingredientsPrefab;
    private int _newID;
    /*Вывод данных о ингредиентах*/
    public void SetIngredientsList(string typeCode)
    {
        _newID = 0;
        foreach (Transform child in ingredientsContent)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < Ingredients.ingredients.Length; i++)
        {
            if (Ingredients.ingredients[i].typeCode.Equals(typeCode) && !Ingredients.ingredients[i].code.Contains("ready"))
            {
                Ingredients.ingredients[i]._id = _newID++;
                var instance = Instantiate(ingredientsPrefab.gameObject);
                instance.transform.SetParent(ingredientsContent, false);
                InitializeResourceItemView(instance, Ingredients.ingredients[i]);
            }
        }
    }
    public void InitializeResourceItemView(GameObject viewGameObject, IngredientsItem ingredients)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.ingredientName.text = ingredients.name;
        view.ingredientsCode.text = ingredients.code;
        view.id.text = ingredients._id.ToString();
        view.sprite.sprite = Resources.Load<Sprite>("Ingridients/" + ingredients.code + "_UI");
    }

    public class ResourcePrefabComponents
    {
        public Text ingredientName, ingredientsCode, id;
        public Image sprite;

        public ResourcePrefabComponents(Transform rootView)
        {
            ingredientName = rootView.Find("Ingredients_Name").GetComponent<Text>();
            ingredientsCode = rootView.Find("Code").GetComponent<Text>();
            id = rootView.Find("IngridientsOnList").GetComponent<Text>();
            sprite = rootView.Find("IconIngredients").GetComponent<Image>();
        }
    }
}
