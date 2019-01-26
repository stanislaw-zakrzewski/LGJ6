using System.Collections;
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

    void Start()
    {
        shelfs = new List<GameObject>();
        items = new List<GameObject>();
        y = itemsPlane.transform.position.y;
        initialItemsX = itemsPlane.transform.position.x;
        for (int i = 0; i < itemsCount; i++)
        {
            AddItem();
        }
        Debug.Log(scrollbar.transform.position);
    }

    void FixedUpdate()
    {
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
            totalItemsLength += 156;
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
        items.Add(newItem);

    }
}
