using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDetail : MonoBehaviour
{
    [SerializeField]
    private Text  orderID;
    [SerializeField] private Image payment;
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
        payment.sprite = Resources.Load<Sprite>("Payment/" + order.paymentID);
        view.name.text = order.name.ToString();
        view.comment.text = "Комментарий:\n";
        view.icon.sprite = Resources.Load<Sprite>("Recipes/" + LevelData.LevelCode + "/" + order.code);
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
        public Image icon;

        public ResourcePrefabComponents(Transform rootView)
        {
            name = rootView.Find("DishName").GetComponent<Text>();
            comment = rootView.Find("Text").GetComponent<Text>();
            icon = rootView.Find("DishIcon").GetComponent<Image>();
        }
    }

    public void SetOrderId()
    {
        orderID.text = "#" + LevelData.OrderID.ToString("0000");
        
    }
}
