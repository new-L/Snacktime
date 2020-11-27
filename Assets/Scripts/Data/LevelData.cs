using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private LevelDataControll _levelDataControll;
    private static int 
        m_Money,
        m_OrderCheck,
        m_OrderUnCheck,
        m_OrderID;

    private static string m_CurrentNoteType;
    private static string m_RecipeCode;
    private static string m_LevelCode;
    
    public static int Money { get => m_Money; set => m_Money = value; }
    public static int OrderCheck { get => m_OrderCheck; set => m_OrderCheck = value; }
    public static int OrderUnCheck { get => m_OrderUnCheck; set => m_OrderUnCheck = value; }
    public static int OrderID { get => m_OrderID; set => m_OrderID = value; }
    public static string RecipeCode { get => m_RecipeCode; set => m_RecipeCode = value; }
    public static string CurrentNoteType { get => m_CurrentNoteType; set => m_CurrentNoteType = value; }
    public static string LevelCode { get => m_LevelCode; set => m_LevelCode = value; }
}
