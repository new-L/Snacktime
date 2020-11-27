using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SetLevel : MonoBehaviour
{
    public Levels[] levels;
    /*Контент ресурсов*/
    [SerializeField] private RectTransform levelContent;
    /*Префаб ресурсов персонажа*/
    [SerializeField] private RectTransform levelPrefab;
    private void Start()
    {
        Load();
        SetLevelsList();
    }

    public void Load()
    {
        string levelsJSON = PlayerPrefs.GetString("levels");
        levels = JsonHelper.FromJson<Levels>(levelsJSON);
    }
    public void Save()
    {
        string levelsJSON = JsonHelper.ToJson(levels);
        PlayerPrefs.SetString("levels", levelsJSON);
        PlayerPrefs.Save();
    }



    public void SetLevelsList()
    {
        foreach (Transform child in levelContent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < levels.Length; i++)
        {
                var instance = Instantiate(levelPrefab.gameObject);
                instance.transform.SetParent(levelContent, false);
                InitializeResourceItemView(instance, levels[i]);
        }
    }
    public void InitializeResourceItemView(GameObject viewGameObject, Levels levels)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.levelName.text = levels.name;
        view.levelCode.text = levels.code;
        view.sprite.sprite = Resources.Load<Sprite>("Levels/Images/" + levels.code);
        if(levels.locked.Equals("locked"))
        {
            view.locked.color = new Color32(255, 255, 255, 255);
            viewGameObject.GetComponent<Button>().enabled = false;
        }
        else
        {
            view.locked.color = new Color32(255, 255, 255, 0);
            viewGameObject.GetComponent<Button>().enabled = true;
        }
    }

    public class ResourcePrefabComponents
    {
        public Text levelName, levelCode;
        public Image sprite, locked;

        public ResourcePrefabComponents(Transform rootView)
        {
            levelName = rootView.Find("LevelName").GetComponent<Text>();
            levelCode = rootView.Find("Code").GetComponent<Text>();
            sprite = rootView.Find("BG").GetComponent<Image>();
            locked = rootView.Find("lock").GetComponent<Image>();
        }
    }


}

[Serializable]
public class Levels
{
    public string name, code, locked;
}

