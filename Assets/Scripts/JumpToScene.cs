using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToScene : MonoBehaviour
{
    private GameObject backgroundMusic;
    public void Jump()
    {
        SceneManager.LoadScene("PreLevel");
    }
    public void Jump(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void MusicReset()//Костыль
    {
        backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundSOund");
        Destroy(backgroundMusic);
    }
}
