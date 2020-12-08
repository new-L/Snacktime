using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    private static bool isSoundEnable = true;

    public static bool IsSoundEnable { get => isSoundEnable; set => isSoundEnable = value; }
}
