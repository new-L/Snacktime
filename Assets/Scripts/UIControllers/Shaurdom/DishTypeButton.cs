using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishTypeButton : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Text code, type;
    [SerializeField] private SetIngredients m_SetType;
    [SerializeField] private OpenMenu openMenu;
    [SerializeField] private Text text;

    private void Start()
    {
        code = root.Find("TypeCode").GetComponent<Text>();
        m_SetType = FindObjectOfType<SetIngredients>();
        openMenu = FindObjectOfType<OpenMenu>();
        
    }
    public void OpenList()
    {
        LevelData.CurrentNoteType = type.text;
        openMenu.OpenPanel("NotePanel");
        text = GameObject.FindGameObjectWithTag("NoteTypeText").GetComponent<Text>();
        m_SetType.SetIngredientsList(code.text);
        text.text = LevelData.CurrentNoteType;
        openMenu.ClosePanel("IngredientsTypePanel");
    }
}
