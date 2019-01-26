using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject floor;
    private Vector3 offset = new Vector3(1, 0,0);
    public GunBase gun;
    public int level;
    public float range;
    public float cooldown;
    public float damage;
    public float velocity;
    public float cost;
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

    void Update()
    {
        if (cost > PlayerPrefs.GetFloat("money"))
        {
            transform.parent.gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            transform.parent.gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
