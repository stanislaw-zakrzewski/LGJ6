using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    void Start()
    {
        transform.position = transform.parent.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = transform.parent.transform.position;
    }
}
