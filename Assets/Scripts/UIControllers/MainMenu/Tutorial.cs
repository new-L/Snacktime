using System.Collections;
using System;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static TutorialItem[] tutorial;

    void Start()
    {
        TextAsset temp = Resources.Load<TextAsset>("Tutorial/Tutorial");
        string json = JsonHelper.fixJson(temp.text);
        print(json);
        tutorial = JsonHelper.FromJson<TutorialItem>(json);
    }
}

[Serializable]
public class TutorialItem
{
    public string title, description, code;
}
