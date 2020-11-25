using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour
{
    private static int currentPrice;
    public static Dictionary<string, int> buscket = new Dictionary<string, int>();

    public static int CurrentPrice { get => currentPrice; set => currentPrice = value; }
}
