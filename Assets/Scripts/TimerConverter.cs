using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerConverter : MonoBehaviour
{
    public string Convert(int totalSeconds)
    {
        return (totalSeconds / 60).ToString("00") + ":" + (totalSeconds % 60).ToString("00");
    }
}
