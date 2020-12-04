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
    public List<AdditionalItem> actualAdditionalOrder;
    public CheckDishWithOrder check;//delete
    private void Start()
    {
        actualOrderList.Clear();
    }


    /*Вывод данных о ингредиентах*/
    public void SetOrdersList(bool start)
    {
        if (start)
        {
            actualOrderList.Clear();
            actualAdditionalOrder.Clear();
        }
        foreach (Transform child in ordersContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddOrder(OrderItem model)
    {
        actualOrderList.Add(model);
        GameObject instance = Instantiate(orderPrefab.gameObject);
        instance.transform.SetParent(ordersContent, false);
        InitializeOrderItemView(instance, model);
        check.prefabs.Add(instance);
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
