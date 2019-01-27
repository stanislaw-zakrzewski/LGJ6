using System.Collections.Generic;
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
    public Sprite gunSprite;
    public Sprite part1Sprite;
    public Sprite part2Sprite;
    public Sprite part3Sprite;
    public Sprite bulletSprite;
    public Color gunColor;
    public Color part1Color;
    public Color part2Color;
    public Color part3Color;
    public Color bulletColor;
    public List<Sprite> bullets;

    private Text text;
    void Start()
    {
        transform.position = transform.parent.transform.position;
        Debug.Log(cost);
        //transform.parent.gameObject.GetComponentInChildren<Text>().text = cost.ToString();
        //text = Instantiate(textBase) as Text;
        //text.GetComponent<Text>().text = cost.ToString();
        //text.GetComponent<Text>().transform.SetParent(transform.parent.transform);
        //text.transform.SetParent(transform.parent.transform);
        gunColor = Random.ColorHSV();
        part1Color = Random.ColorHSV();
        part2Color = Random.ColorHSV();
        part3Color = Random.ColorHSV();
        gameObject.GetComponent<Image>().sprite = gunSprite;
        gameObject.GetComponent<Image>().color = gunColor;
        transform.Find("Part1").gameObject.GetComponent<Image>().sprite = part1Sprite;
        transform.Find("Part1").gameObject.GetComponent<Image>().color = part1Color;
        transform.Find("Part2").gameObject.GetComponent<Image>().sprite = part2Sprite;
        transform.Find("Part2").gameObject.GetComponent<Image>().color = part2Color;
        transform.Find("Part3").gameObject.GetComponent<Image>().sprite = part3Sprite;
        transform.Find("Part3").gameObject.GetComponent<Image>().color = part3Color;
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
