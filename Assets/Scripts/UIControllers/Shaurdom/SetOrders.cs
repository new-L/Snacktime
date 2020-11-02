using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOrders : MonoBehaviour
{
    /*Контент заказов*/
    [SerializeField] private RectTransform ordersContent;
    /*Префаб заказа*/
    [SerializeField] private RectTransform orderPrefab;
    /*Заказы*/
    [SerializeField] private Order orders;

    public List<OrderItem> actualOrderList;

    public int timer = 100;
    /*Вывод данных о ингредиентах*/
    public void SetOrdersList()
    {
        actualOrderList.Clear();
        foreach (Transform child in ordersContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddOrder(OrderItem model)
    {
        actualOrderList.Add(model);
        var instance = Instantiate(orderPrefab.gameObject);
        instance.transform.SetParent(ordersContent, false);
        InitializeOrderItemView(instance, model);
    }

    
    public void InitializeOrderItemView(GameObject viewGameObject, OrderItem order)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.timer.text = order.cookingtime.ToString();
        view.orderID.text = order.id.ToString();
    }

    public class ResourcePrefabComponents
    {
        public Text timer, orderID;

        public ResourcePrefabComponents(Transform rootView)
        {
            timer = rootView.Find("Timer").GetComponent<Text>();
            orderID = rootView.Find("OrderID").GetComponent<Text>();
        }
    }


}
