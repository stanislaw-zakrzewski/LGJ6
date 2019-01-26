using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public float maxHealth;
    public float movementSpeed;
    public float givenDamage;
    public GameObject target;
    private float health;


    //Use this for initialization
    void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().position = new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x+movementSpeed, Mathf.Sin(Time.frameCount/10f));
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<House>())
        {
            collision.gameObject.GetComponent<House>().TakeDamage(givenDamage);
        }
    }
}
