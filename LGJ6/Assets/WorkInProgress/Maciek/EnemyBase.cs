using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    private float health;
    public float movementSpeed;
    public float add;

    
    //Use this for initialization
	void Start () {
        movementSpeed = 0.05f;
        
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    void FixedUpdate()
    {
        add = Time.frameCount;
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
