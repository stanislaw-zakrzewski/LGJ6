using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorBuilding : MonoBehaviour {
    public List<GameObject> floors;
    public List<GameObject> slots;
    public List<GameObject> costs;
    public float floor2Cost;
    public float floor3Cost;
    public float floor4Cost;
    public float floor5Cost;
	// Use this for initialization
	void Start () {
		foreach(var floor in floors)
        {
            floor.GetComponent<SpriteRenderer>().enabled = false;
        }
        for(int i = 1; i < slots.Count; i++)
        {
            slots[i].SetActive(false);
            costs[i].SetActive(false);
        }
        costs[0].gameObject.GetComponentInChildren<Text>().text = floor2Cost.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
