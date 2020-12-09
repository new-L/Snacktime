using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTitle : MonoBehaviour
{
    [SerializeField] private Text desc, code;
    [SerializeField] private Image screen;
    [SerializeField] private AudioSource click;

    private void Start()
    {
        click = GameObject.FindGameObjectWithTag("MainMenuSoundEffect").GetComponent<AudioSource>();
        desc = GameObject.FindGameObjectWithTag("TutorialText").GetComponent<Text>();
        screen = GameObject.FindGameObjectWithTag("TutorialImage").GetComponent<Image>();
    }
    public void SetDescription()
    {
        click.Play();
        desc.color = new Color32(255, 253, 150, 255);
        screen.color = new Color32(255, 255, 255, 255);
        foreach (var item in Tutorial.tutorial)
        {
            if(item.code.Equals(code.text))
            {
                desc.text = item.description;
                screen.sprite = Resources.Load<Sprite>("Tutorial/Images/" + item.code);
                break;
            }
        }
    }

}
