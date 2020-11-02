using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private static int 
        m_Money,
        m_OrderCheck,
        m_OrderUnCheck,
        m_OrderID;

    public static int Money { get => m_Money; set => m_Money = value; }
    public static int OrderCheck { get => m_OrderCheck; set => m_OrderCheck = value; }
    public static int OrderUnCheck { get => m_OrderUnCheck; set => m_OrderUnCheck = value; }
    public static int OrderID { get => m_OrderID; set => m_OrderID = value; }
}
