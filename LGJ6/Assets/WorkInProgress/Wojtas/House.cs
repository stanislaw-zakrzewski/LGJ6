using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public float maxHealth;
    public float startingMoney;
    public float traveledDistance;
    private float money;
    private float health;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        money = startingMoney;
        PlayerPrefs.DeleteKey("money");
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("siema " + money);
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
        //TEMPORARY!!!!!!!!!!!!
        traveledDistance += 0.01f;
        PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
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
