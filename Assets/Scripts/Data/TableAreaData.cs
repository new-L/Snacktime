using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TableAreaData : MonoBehaviour, IDropHandler
{
    [SerializeField] private SetIngredients setIngredients;

    private static string _code;
    private static bool _fromStove;

    public static string Code { get => _code; set => _code = value; }
    public static bool FromStove { get => _fromStove; set => _fromStove = value; }

    private string _readyIngridientsPath;
    public List<CurrentDish> dish;
    [SerializeField] private RectTransform _tableArea;
    [SerializeField] private RectTransform _realIngridientsPrefab;
    public void OnDrop(PointerEventData eventData)
    {
        _readyIngridientsPath = "Ingridients/Real" + Code;
        if (eventData.pointerDrag != null && Resources.Load<Sprite>(_readyIngridientsPath) != null)
        {
            if (CheckBasisIngridient())
            {
                SetItem();
                for (int i = 0; i < Ingredients.ingredients.Length; i++)
                {
                    if (Ingredients.ingredients[i].code.Equals(_code) && !Ingredients.ingredients[i].code.Contains("ready"))
                    {
                        Ingredients.ingredients[i].count -= 1;
                        setIngredients.InitializeResourceItemView(eventData.pointerDrag, Ingredients.ingredients[i]);
                        break;
                    }
                }
            }
            else if (GetTypeCode().Equals("basis"))//если мы добавляем основной компонент
            {
                SetItem();
                for (int i = 0; i < Ingredients.ingredients.Length; i++)
                {
                    if (Ingredients.ingredients[i].code.Equals(_code))
                    {
                        Ingredients.ingredients[i].count -= 1;
                        setIngredients.InitializeResourceItemView(eventData.pointerDrag, Ingredients.ingredients[i]);
                        break;
                    }
                }
            }
            else
                print("Где основной ингридиент?");

        }
        StoveItemDragDrop.dropedOnTable = true;
    }

    private void ItemFromStove(GameObject eventData)
    {
        if(_fromStove)
        {
            StoveData.Blocked = false;
            StoveData.Code = "";
        }
    }
    //Проверяем тип продукта(основа, начинка и т.п.)
    private string GetTypeCode()
    {
        foreach (var item in Ingredients.ingredients)
            if (Code.Equals(item.code))
                return item.typeCode;
        return "null";
    }

    //Проверяем наличие базиса для готовки
    private bool CheckBasisIngridient()
    {
        foreach(CurrentDish item in dish)
        {
            if (item.typeCode.Equals("basis"))
                return true;
        }
        return false;
    }

    #region Установка нового айтема на стол
    private void SetItem()
    {
        bool flag = true;
        foreach (var item in dish)
        {
            if (item.code.Equals(Code))
            {
                flag = false;
                InitializeCurrentDish(false, item);
            }
        }
        if (flag)
        {
            foreach (var model in Ingredients.ingredients)
            {
                if (model.code.Equals(Code))
                {
                    print(Code);
                    var instance = Instantiate(_realIngridientsPrefab.gameObject);
                    instance.transform.SetParent(_tableArea, false);
                    InitializeRealItemView(instance, model);
                    break;
                }
            }
            InitializeCurrentDish(true, null);
        }
    }

    public void InitializeRealItemView(GameObject viewGameObject, IngredientsItem ingredients)
    {
        RealPrefabComponents view = new RealPrefabComponents(viewGameObject.transform);
        view.ingridient.sprite = Resources.Load<Sprite>(_readyIngridientsPath);
        SetImageNativeSize(view.ingridient);
    }
    public void InitializeCurrentDish(bool addable, CurrentDish item)
    {
        if (addable)
            dish.Add(new CurrentDish(Code, GetTypeCode(), 1));
        else
            item.count++;
    }

    public class RealPrefabComponents
    {
        public Image ingridient;
        public RealPrefabComponents(Transform rootView)
        {
            ingridient = rootView.GetComponent<Image>();
        }
    }
    #endregion

    private void SetImageNativeSize(Image image)
    {
        float aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
        var fitter = image.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;
    }
}

[Serializable]
public class CurrentDish
{
    public string code, typeCode;
    public int count;
    public bool checkable;

    public CurrentDish(string code, string typeCode, int count)
    {
        this.code = code;
        this.typeCode = typeCode;
        this.count = count;
        checkable = false;
    }
}



