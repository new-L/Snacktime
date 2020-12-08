using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnSceneControll : MonoBehaviour
{
    [SerializeField] private GameObject SoundOn, SoundOff;
    private void Start()
    {
        if (!SoundData.IsSoundEnable)
        {
            Mute();
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);


        }
    }
    public void OnClickSound(AudioSource _buttonCound)
    {
        _buttonCound.Play();
    }

    public void Mute()
    {
        SoundData.IsSoundEnable = false;
        AudioListener.volume = 0f;
    }
    public void UnMute()
    {
        SoundData.IsSoundEnable = true;
        AudioListener.volume = 1f;
    }

}
