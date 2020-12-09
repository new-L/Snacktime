using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    private static bool isSoundEnable = true;
    private static bool isSoundPlaying = true;

    public static bool IsSoundEnable { get => isSoundEnable; set => isSoundEnable = value; }
    public static bool IsSoundPlaying { get => isSoundPlaying; set => isSoundPlaying = value; }
}

