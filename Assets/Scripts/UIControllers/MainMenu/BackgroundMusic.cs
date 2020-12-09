using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private GameObject MusicObject;
    private void Awake()
    {
        if (this.MusicObject != null)
        {
            DontDestroyOnLoad(MusicObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Menu" && scene.name != "LevelMenu")
        {
            SoundData.IsSoundPlaying = false;
            Destroy(this.MusicObject);
        }
    }
}
