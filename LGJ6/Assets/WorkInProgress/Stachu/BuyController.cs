using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyController : MonoBehaviour
{
    public GameObject itemsPlane;
    public Scrollbar scrollbar;
    public int itemsCount;
    public GameObject shelf;
    public GameObject item;
    public GameObject gun;

    private float initialItemsX;
    private float y;
    private List<GameObject> shelfs;
    private List<GameObject> items;
    private float totalItemsLength;
    public List<Sprite> guns;
    public List<Sprite> parts;
    private float dist;

    void Start()
    {
        dist = 0;
        shelfs = new List<GameObject>();
        items = new List<GameObject>();
        y = itemsPlane.transform.position.y;
        initialItemsX = itemsPlane.transform.position.x;
        for (int i = 0; i < itemsCount; i++)
        {
            AddItem();
        }
    }

    void FixedUpdate()
    {
        if (PlayerPrefs.GetFloat("traveledDistance") > dist + 10)
        {
            dist = PlayerPrefs.GetFloat("traveledDistance");
            AddItem();
        }
        

        scrollbar.transform.position = new Vector2(scrollbar.transform.position.x, 27);
        float width = itemsPlane.GetComponent<RectTransform>().rect.size.x;
        itemsPlane.transform.position = new Vector2(initialItemsX - scrollbar.value * (width - 1920), y);
    }

    private void LateUpdate()
    {
        scrollbar.transform.position = new Vector2(scrollbar.transform.position.x, 27);
    }

    void AddItem()
    {
        if (shelfs.Count != 0)
        {
            GameObject newButton = Instantiate(shelf);
            newButton.transform.SetParent(itemsPlane.transform);
            newButton.transform.position = new Vector2(shelfs[shelfs.Count - 1].transform.position.x + 156, y);
            shelfs.Add(newButton);
            totalItemsLength += 157;
            if (totalItemsLength > itemsPlane.GetComponent<RectTransform>().rect.size.x)
            {
                itemsPlane.GetComponent<RectTransform>().sizeDelta = new Vector2(totalItemsLength - 1920, itemsPlane.GetComponent<RectTransform>().sizeDelta.y);
                initialItemsX += 156 / 2;
                foreach (var item in shelfs)
                {
                    item.transform.position = new Vector2(item.transform.position.x - 150 / 2, item.transform.position.y);
                }
                initialItemsX = totalItemsLength / 2;
            }
        }
        else
        {
            GameObject newButton = Instantiate(shelf);
            newButton.transform.SetParent(itemsPlane.transform);
            newButton.transform.position = new Vector2(81, y);
            shelfs.Add(newButton);
            totalItemsLength = 162;
        }
        GameObject newItem = Instantiate(item);
        newItem.transform.SetParent(shelfs[shelfs.Count - 1].transform);
        newItem.GetComponent<ShopItem>().damage = shelfs.Count + 10;
        newItem.GetComponent<ShopItem>().cooldown = 1.0f / shelfs.Count;
        float scl = 1f;
        if (shelfs.Count % 3 == 0) scl = 0.7f;
        if (shelfs.Count % 3 == 2) scl = 1.3f;
        int ct = shelfs.Count / 3;
        newItem.GetComponent<ShopItem>().cost = (int)((50 + ct * ct * ct * ct) * scl);

        // dist = velocity + (damage + lifesteal) / cooldown

        float ss = 1f / (1f + Mathf.Pow(2.718f, -shelfs.Count / 5f)) * 4500;
        float lvl = (dist*10 + 10)*scl;
        float lvlP = lvl;
        
        newItem.GetComponent<ShopItem>().velocity = Random.Range(500, 500 + ss) / 10000;
        lvl -= newItem.GetComponent<ShopItem>().velocity;
        newItem.GetComponent<ShopItem>().cooldown = Random.Range(0.2f, 2f);
        lvl *= newItem.GetComponent<ShopItem>().cooldown;
        newItem.GetComponent<ShopItem>().range = Random.Range(0f, lvl/lvlP*2f);
        lvl /= newItem.GetComponent<ShopItem>().range + 1;
        newItem.GetComponent<ShopItem>().damage = lvl;
        newItem.GetComponent<ShopItem>().level = shelfs.Count;
        newItem.GetComponent<ShopItem>().gunSprite = guns[Random.Range(0, 7)];
        newItem.GetComponent<ShopItem>().part1Sprite = parts[Random.Range(0, 2)];
        newItem.GetComponent<ShopItem>().part2Sprite = parts[Random.Range(0, 2)];
        newItem.GetComponent<ShopItem>().part3Sprite = parts[Random.Range(0, 2)];
        items.Add(newItem);

    }
}
