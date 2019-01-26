using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public float maxHealth;
    public float startingMoney;
    private float money;
    private float health;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        money = 0;
        PlayerPrefs.DeleteKey("money2");
        PlayerPrefs.SetFloat("money2", 0);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("siema " + money);
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void AddMoney(float amount)
    {
        Debug.Log("przed " + money);
        money += amount;
        Debug.Log("po " + money);
        PlayerPrefs.SetFloat("money2", money);
    }

    public float GetMoney()
    {
        return money;
    }

    
}
