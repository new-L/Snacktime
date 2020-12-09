using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void StartNewGame()
    {
        TextAsset temp = Resources.Load<TextAsset>("Levels/levels");
        string json = JsonHelper.fixJson(temp.text);
        PlayerPrefs.SetString("levels", json);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LevelMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }

}

