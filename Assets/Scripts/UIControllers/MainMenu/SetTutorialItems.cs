using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTutorialItems : MonoBehaviour
{
    /*Контент рецепта*/
    [SerializeField] private RectTransform itemTutorialContent;
    /*Префаб ингридента рецепта*/
    [SerializeField] private RectTransform itemTutorialPrefab;
    [SerializeField] private Text text;
    [SerializeField] private Image image;


    public void SetItemIngredientsList()
    {
        text.color = new Color32(255, 255, 255, 0);
        image.color = new Color32(255, 255, 255, 0);
        foreach (Transform child in itemTutorialContent)
        {
            Destroy(child.gameObject);
        }
        foreach(var item in Tutorial.tutorial)
        {
            var instance = Instantiate(itemTutorialPrefab.gameObject);
            instance.transform.SetParent(itemTutorialContent, false);
            InitializeItemItemView(instance, item);
        }
    }
    public void InitializeItemItemView(GameObject viewGameObject, TutorialItem item)
    {
        ItemPrefabComponents view = new ItemPrefabComponents(viewGameObject.transform);
        view.title.text = item.title;
        view.code.text = item.code;
    }

    public class ItemPrefabComponents
    {
        public Text title, code;

        public ItemPrefabComponents(Transform rootView)
        {
            title = rootView.Find("Title").GetComponent<Text>();
            code = rootView.Find("Code").GetComponent<Text>();
        }
    }
}
