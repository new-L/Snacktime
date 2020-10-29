using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishTypeButton : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Text code;
    [SerializeField] private SetIngredients m_SetType;
    [SerializeField] private OpenMenu openMenu;

    private void Start()
    {
        code = root.Find("TypeCode").GetComponent<Text>();
        m_SetType = FindObjectOfType<SetIngredients>();
        openMenu = FindObjectOfType<OpenMenu>();
    }
    public void OpenList()
    {
        openMenu.OpenPanel("NotePanel");
        m_SetType.SetIngredientsList(code.text);
        openMenu.ClosePanel("IngredientsTypePanel");
    }
}
