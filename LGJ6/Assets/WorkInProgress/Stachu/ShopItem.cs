using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject floor;
    private Vector3 offset = new Vector3(1, 0,0);
    void Start()
    {
        transform.position = transform.parent.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = transform.parent.transform.position;
    }
}
