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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("oko");
        if(currentGun != null)
        {
            Destroy(currentGun.gameObject);
        }
        currentGun = Instantiate(gun);
        currentGun.transform.SetParent(floor.transform);
        currentGun.transform.position = new Vector2(floor.transform.position.x + 2, floor.transform.position.y + .7f);
        currentGun.GetComponent<GunBase>().spawner = spawner;
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
