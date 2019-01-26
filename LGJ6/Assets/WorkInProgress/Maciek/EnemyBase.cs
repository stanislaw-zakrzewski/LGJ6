using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public float maxHealth;
    private float health;
    public float movementSpeed;
    private float givenDamage;

    
    //Use this for initialization
	void Start () {
        //Some random numbers
        movementSpeed = 0.05f;
        health = maxHealth;
        givenDamage = 5f;
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

}
