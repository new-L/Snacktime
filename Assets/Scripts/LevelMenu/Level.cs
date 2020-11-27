using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Text code;
    public void JumpToLevel()
    {
        LevelData.LevelCode = code.text;
        SceneManager.LoadScene(code.text);
    }
}
