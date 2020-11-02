using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDetail : MonoBehaviour
{
    [SerializeField]
    private Text  orderID;
    /*Контент заказов*/
    [SerializeField] private RectTransform dishContent;
    /*Префаб заказа*/
    [SerializeField] private RectTransform dishPrefab;
    /*Заказы*/
    [SerializeField] private SetOrders orders;

    public void SetOrderDetail()
    {
        SetOrderId();
        foreach (Transform child in dishContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in orders.actualOrderList)
        {
            if (model.id == LevelData.OrderID)
            {
                var instance = Instantiate(dishPrefab.gameObject);
                instance.transform.SetParent(dishContent, false);
                InitializeDetailItemView(instance, model);
            }
        }
    }



    public void InitializeDetailItemView(GameObject viewGameObject, OrderItem order)
    {
        ResourcePrefabComponents view = new ResourcePrefabComponents(viewGameObject.transform);
        view.name.text = order.name.ToString();
        view.comment.text = "Комментарий:\n";
        foreach (var model in order.ingredients)
        {
            if (!model.setable)
            {
                view.comment.text += "- БЕЗ " + model.type + ";\n";
            }
        }
        
    }

    public class ResourcePrefabComponents
    {
        public Text name, comment;

        public ResourcePrefabComponents(Transform rootView)
        {
            name = rootView.Find("DishName").GetComponent<Text>();
            comment = rootView.Find("Text").GetComponent<Text>();
        }
    }

    public void SetOrderId()
    {
        orderID.text = "#" + LevelData.OrderID.ToString("0000");
    }
}
