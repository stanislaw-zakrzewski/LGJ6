using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler
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
    public Text textBase;
    private Text text;
    void Start()
    {
        transform.position = transform.parent.transform.position;
        Debug.Log(cost);
        transform.parent.gameObject.GetComponentInChildren<Text>().text = cost.ToString();
        //text = Instantiate(textBase) as Text;
        //text.GetComponent<Text>().text = cost.ToString();
        //text.GetComponent<Text>().transform.SetParent(transform.parent.transform);
        //text.transform.SetParent(transform.parent.transform);
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
        PlayerPrefs.GetFloat("money");
        if (cost > PlayerPrefs.GetFloat("money"))
        {
            transform.parent.gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            transform.parent.gameObject.GetComponent<Image>().color = Color.white;
        }
        //text.gameObject.GetComponent<Text>().text = cost.ToString();
    }

    private void OnMouseOver()
    {
        Debug.Log("kurwa");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerPrefs.SetFloat("damage", damage);
        PlayerPrefs.SetFloat("cooldown", cooldown);
        PlayerPrefs.SetFloat("range", range);
        PlayerPrefs.SetFloat("velocity", velocity);
        PlayerPrefs.SetFloat("cost", cost);
    }
}
