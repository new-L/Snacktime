using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Order : MonoBehaviour
{
    public List<OrderItem> orderItem;
    public int orderCount;
    private int id;
    [SerializeField] private Recipes recipes;
    [SerializeField] private UnityEvent m_OrderEvent;
    [SerializeField] private SetOrders actualOrders;

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
                InvokeRepeating("NewOrder", 7f, 5f);
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
            orderItem.RemoveAt(orderItem.Count - 1);
        }
    }

    private void AddToOrderList(RecipesItem item, RecipeIngredients[] ingr)
    {
        orderItem.Add(new OrderItem(item, ingr, id--));
    }
}

[Serializable]
public class OrderItem
{
    public int id;
    public string name;
    public List<OrderIngredient> ingredients = new List<OrderIngredient>();
    public int cookingtime;
    public int money;

    public OrderItem(RecipesItem item, RecipeIngredients[] ingr, int id)
    {
        this.id = id;
        name = item.name;
        foreach(var ingredient in ingr)
        {
            if(ingredient.refuse.Equals("optional"))
                ingredients.Add(new OrderIngredient(ingredient.type, ingredient.refuse, UnityEngine.Random.Range(0, 11) <= 6, ingredient.count, ingredient.typeCode));
            else
                ingredients.Add(new OrderIngredient(ingredient.type, ingredient.refuse, true, ingredient.count, ingredient.typeCode));
        }        
        cookingtime = item.cookingtime;
        money = item.money;
    }
}

[Serializable]
public class OrderIngredient
{
    public string type, refuse, typeCode;
    public bool setable;
    public int count;

    public OrderIngredient(string type, string refuse, bool setable, int count, string typeCode)
    {
        this.type = type;
        this.refuse = refuse;
        this.setable = setable;
        this.count = count;
        this.typeCode = typeCode;
    }
}

