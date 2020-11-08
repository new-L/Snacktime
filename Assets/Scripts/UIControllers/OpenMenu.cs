using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public List<GameObject> m_Menus;
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    
    public void OpenPanel(string panelTag)
    {
        FindObject(panelTag).SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
    public void CloseAllPanel()
    {
        for(int i = 0; i < m_Menus.Count; i++)
        {
            if (m_Menus[i].tag.Equals("IngredientsTypePanel") || m_Menus[i].tag.Equals("NotePanel"))
            {
                if (m_Menus[i].activeSelf)
                    m_Menus[i].SetActive(true);
            }
            else  m_Menus[i].SetActive(false);
        }
    }
    public void ClosePanel(string panelTag)
    {
        FindObject(panelTag).SetActive(false);
    }
    private GameObject FindObject(string key)
    {
        GameObject temp = null;
        foreach(var obj in m_Menus)
            if (obj.tag.Equals(key))
                temp = obj;
        return temp;
    }
}
