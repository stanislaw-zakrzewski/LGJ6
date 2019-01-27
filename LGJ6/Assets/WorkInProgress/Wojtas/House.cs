using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public float maxHealth;
    public float startingMoney;
    public float traveledDistance;
    private float money;
    public float health;
    public GameObject mapMove;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        money = startingMoney;
        traveledDistance = 1f;
        PlayerPrefs.DeleteKey("money");
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
        PlayerPrefs.SetFloat("health", health);
        PlayerPrefs.SetFloat("maxHealth", maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("siema " + money);
        if (health <= 0f)
        {
            health = maxHealth;
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") * 0.75f);
            PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("maxHealth"));
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Find("koloL").transform.Rotate(new Vector3(0, 0, -1));
            gameObject.transform.Find("koloP").transform.Rotate(new Vector3(0, 0, -1));
            mapMove.gameObject.GetComponent<MapGenerator>().MoveRight();
            traveledDistance += 0.01f;
            PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Find("koloL").transform.Rotate(new Vector3(0, 0, 1));
            gameObject.transform.Find("koloP").transform.Rotate(new Vector3(0, 0, 1));
            mapMove.gameObject.GetComponent<MapGenerator>().MoveLeft();
            if (traveledDistance - 0.01f < 0) traveledDistance = 0f;
            else traveledDistance -= 0.01f;
            PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        PlayerPrefs.SetFloat("health", health);
    }

    public void AddMoney(float amount)
    {
        //Debug.Log("przed " + money);
        money += amount;
        //Debug.Log("po " + money);
        PlayerPrefs.SetFloat("money", money);
    }

    public float GetMoney()
    {
        return money;
    }

    
}
