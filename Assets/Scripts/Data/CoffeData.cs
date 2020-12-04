using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeData : MonoBehaviour
{
    private static bool isCoffee;

    public static bool IsCoffee { get => isCoffee; set => isCoffee = value; }
}
