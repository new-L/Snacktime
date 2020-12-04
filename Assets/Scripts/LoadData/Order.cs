using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Order : MonoBehaviour
{
    public List<OrderItem> orderItem;
    public int orderCount;
    public float speed;
    private int id;
    [SerializeField] private Recipes recipes;
    [SerializeField] private UnityEvent m_OrderEvent;
    [SerializeField] private SetOrders actualOrders;
    [SerializeField] private AddIngredients randomIngredient;

    public void Generate()
    {
        id = orderCount;
        orderItem.Clear();
        while(true)//Очень дорого для проца, но времени нет
        {
            if (orderItem.Count < orderCount)
            {
                foreach (var item in recipes.recipes)
                {
                    if (UnityEngine.Random.Range(1, 101) >= 70)
                    {
                        AddToOrderList(item, item.ingredients);
                    }
                }
            }
            else
            {
                if(orderItem.Count > orderCount)
                {
                    orderItem.RemoveRange(orderCount, orderItem.Count - orderCount);
                    print("Deleted");
                }
                if (m_OrderEvent == null) m_OrderEvent = new UnityEvent();
                m_OrderEvent.Invoke();
                InvokeRepeating("NewOrder", 7f, speed);
                break;
            }
            
        }

    }

    private void NewOrder()
    {
        if (orderItem.Count <= 0) CancelInvoke("NewOrder");
        else
        {
            actualOrders.AddOrder(orderItem[orderItem.Count - 1]);
            if (LevelData.LevelCode.Equals("eldoroga")) { AdditionalIngridient(orderItem[orderItem.Count - 1].id); }
            orderItem.RemoveAt(orderItem.Count - 1);
        }
    }

    private void AddToOrderList(RecipesItem item, RecipeIngredients[] ingr)
    {
        orderItem.Add(new OrderItem(item, ingr, id--, item.code, UnityEngine.Random.Range(1, 6)));
    }

    private void AdditionalIngridient(int id)
    {
        if(UnityEngine.Random.Range(1, 11) < 8)
        {
            actualOrders.actualAdditionalOrder.Add(new AdditionalItem(id, randomIngredient.addIngr[0].name, randomIngredient.addIngr[0].code));
        }
    }
}

[Serializable]
public class OrderItem
{
    public int id, paymentID;
    public string name, code;
    public List<OrderIngredient> ingredients = new List<OrderIngredient>();
    public int cookingtime;
    public int money;

    public OrderItem(RecipesItem item, RecipeIngredients[] ingr, int id, string code, int payment)
    {
        this.id = id;
        paymentID = payment;
        this.code = code;
        name = item.name;
        foreach(var ingredient in ingr)
        {
            if(ingredient.refuse.Equals("optional"))
                ingredients.Add(new OrderIngredient(ingredient.type, ingredient.refuse, UnityEngine.Random.Range(0, 11) <= 6, ingredient.count, ingredient.typeCode, ingredient.nameCode));
            else
                ingredients.Add(new OrderIngredient(ingredient.type, ingredient.refuse, true, ingredient.count, ingredient.typeCode, ingredient.nameCode));
        }        
        cookingtime = item.cookingtime;
        money = item.money;
    }
}

[Serializable]
public class OrderIngredient
{
    public string type, refuse, typeCode, nameCode;
    public bool setable;
    public int count;

    public OrderIngredient(string type, string refuse, bool setable, int count, string typeCode, string nameCode)
    {
        this.type = type;
        this.refuse = refuse;
        this.setable = setable;
        this.count = count;
        this.typeCode = typeCode;
        this.nameCode = nameCode;
    }
}

[Serializable]
public class AdditionalItem
{
    public int id;
    public string name, code;
    public AdditionalItem(int _id, string _name, string _code)
    {
    id  =_id;
        name = _name;
        code = _code;
}
   }

