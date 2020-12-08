using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Text code;
    [SerializeField] private AudioSource ButtonSoud;
    private void Start()
    {
        ButtonSoud = GameObject.FindGameObjectWithTag("UISound").GetComponent<AudioSource>();
    }
    public void JumpToLevel()
    {
        ButtonSoud.Play();
        LevelData.LevelCode = code.text;
        SceneManager.LoadScene(code.text);
    }
}
