using System.Collections;
using System;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    public LevelTemp[] levels;
    public void Load()
    {
        string levelsJSON = PlayerPrefs.GetString("levels");
        levels = JsonHelper.FromJson<LevelTemp>(levelsJSON);
    }
    public void Save()
    {
        string levelsJSON = JsonHelper.ToJson(levels);
        PlayerPrefs.SetString("levels", levelsJSON);
        PlayerPrefs.Save();
    }
}

[Serializable]
public class LevelTemp
{
    public string name, code, locked;
}

