using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorBuilding : MonoBehaviour
{
    public List<GameObject> floors;
    public List<GameObject> slots;
    public List<GameObject> costs;
    public float floor2Cost;
    public float floor3Cost;
    public float floor4Cost;
    public float floor5Cost;
    public GameObject roof;

    private GameObject currentButton;
    private float currentCost;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("houseLevel", 1);
        foreach (var floor in floors)
        {
            floor.GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 1; i < slots.Count; i++)
        {
            costs[i].gameObject.GetComponentInChildren<Text>().text = "";
            costs[i].GetComponent<Image>().enabled = false;
        }
        costs[0].gameObject.GetComponentInChildren<Text>().text = floor2Cost.ToString();
        currentButton = costs[0];
        currentButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
        currentCost = floor2Cost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked(int button)
    {
        if (button <= PlayerPrefs.GetInt("houseLevel") && PlayerPrefs.GetFloat("money") > currentCost)
        {
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - currentCost);
            Debug.Log("oko");
            currentButton.gameObject.SetActive(false);
            Destroy(currentButton);
            switch (button)
            {
                case 1:
                    currentButton = costs[1];
                    currentButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(2));
                    costs[1].gameObject.GetComponentInChildren<Text>().text = floor3Cost.ToString();
                    costs[button].GetComponent<Image>().enabled = true;
                    currentCost = floor3Cost;
                    break;
                case 2:
                    currentButton = costs[2];
                    currentButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(3));
                    costs[2].gameObject.GetComponentInChildren<Text>().text = floor4Cost.ToString();
                    costs[button].GetComponent<Image>().enabled = true;
                    currentCost = floor4Cost;
                    break;
                case 3:
                    currentButton = costs[3];
                    currentButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(4));
                    costs[3].gameObject.GetComponentInChildren<Text>().text = floor5Cost.ToString();
                    costs[button].GetComponent<Image>().enabled = true;
                    currentCost = floor5Cost;
                    break;
                case 4:
                    break;
            }
            floors[button - 1].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("nos");
            PlayerPrefs.SetInt("houseLevel", PlayerPrefs.GetInt("houseLevel") + 1);
            roof.transform.position = floors[button - 1].transform.position + new Vector3(0,0,0);
        }
    }
}
