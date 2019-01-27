using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Floor : MonoBehaviour, IDropHandler
{
    public GameObject gun;
    private GameObject currentGun;
    public GameObject floor;
    public GameObject spawner;
    public int level;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<ShopItem>().cost <= PlayerPrefs.GetFloat("money") && level <= PlayerPrefs.GetInt("houseLevel"))
        {
            Debug.Log("oko");
            if (currentGun != null)
            {
                Destroy(currentGun.gameObject);
            }
            currentGun = Instantiate(gun);
            Debug.Log(spawner);
            currentGun.GetComponent<GunBase>().damage = eventData.pointerDrag.GetComponent<ShopItem>().damage;
            currentGun.GetComponent<GunBase>().cooldown = eventData.pointerDrag.GetComponent<ShopItem>().cooldown;
            currentGun.GetComponent<GunBase>().cost = eventData.pointerDrag.GetComponent<ShopItem>().cost;
            currentGun.GetComponent<GunBase>().velocity = eventData.pointerDrag.GetComponent<ShopItem>().velocity;
            currentGun.GetComponent<GunBase>().range = eventData.pointerDrag.GetComponent<ShopItem>().range;
            currentGun.transform.SetParent(floor.transform);
            currentGun.transform.position = new Vector2(floor.transform.position.x + 2, floor.transform.position.y + .7f);
            currentGun.GetComponent<GunBase>().spawner = spawner;
            currentGun.gameObject.GetComponent<SpriteRenderer>().sprite = eventData.pointerDrag.GetComponent<ShopItem>().gunSprite;
            currentGun.gameObject.GetComponent<SpriteRenderer>().color = eventData.pointerDrag.GetComponent<ShopItem>().gunColor;
            currentGun.gameObject.transform.Find("Part1").GetComponent<SpriteRenderer>().sprite = eventData.pointerDrag.GetComponent<ShopItem>().part1Sprite;
            currentGun.gameObject.transform.Find("Part1").GetComponent<SpriteRenderer>().color = eventData.pointerDrag.GetComponent<ShopItem>().part1Color;
            currentGun.gameObject.transform.Find("Part2").GetComponent<SpriteRenderer>().sprite = eventData.pointerDrag.GetComponent<ShopItem>().part2Sprite;
            currentGun.gameObject.transform.Find("Part2").GetComponent<SpriteRenderer>().color = eventData.pointerDrag.GetComponent<ShopItem>().part2Color;
            currentGun.gameObject.transform.Find("Part3").GetComponent<SpriteRenderer>().sprite = eventData.pointerDrag.GetComponent<ShopItem>().part3Sprite;
            currentGun.gameObject.transform.Find("Part3").GetComponent<SpriteRenderer>().color = eventData.pointerDrag.GetComponent<ShopItem>().part3Color;
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - eventData.pointerDrag.GetComponent<ShopItem>().cost);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
