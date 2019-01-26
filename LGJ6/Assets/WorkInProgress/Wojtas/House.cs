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
        traveledDistance = 1f;
        PlayerPrefs.DeleteKey("money");
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("siema " + money);
        if (health <= 0f)
        {
            PlayerPrefs.SetFloat("money", 0);
            Destroy(this.gameObject);
        }
        //TEMPORARY!!!!!!!!!!!!
        traveledDistance += 1f;
        PlayerPrefs.SetFloat("traveledDistance", traveledDistance);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Find("koloL").transform.Rotate(new Vector3(0, 0, -1));
            gameObject.transform.Find("koloP").transform.Rotate(new Vector3(0, 0, -1));
            gameObject.GetComponent<Rigidbody2D>().position = new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x + 0.1f, transform.parent.transform.position.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Find("koloL").transform.Rotate(new Vector3(0, 0, 1));
            gameObject.transform.Find("koloP").transform.Rotate(new Vector3(0, 0, 1));
        }
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
