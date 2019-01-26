using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public float maxHealth;
    public float movementSpeed;
    public float givenDamage;
    public GameObject target;
    public enum MovingType
    {
        linear,
        sinus
    }
    public MovingType movingType;
    public float moneyForKilling;
    public Sprite korp1;
    public Sprite korp2;
    public Sprite korp3;
    public Sprite el1;
    public Sprite el2;
    public Sprite el3;
    protected float health;
    protected int level;


    //Use this for initialization
    void Start () {
        health = maxHealth;
        level = 0;
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    void FixedUpdate()
    {
        switch (movingType)
        {
            case MovingType.linear:
                gameObject.GetComponent<Rigidbody2D>().position = new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x - movementSpeed, transform.parent.transform.position.y);
                break;
            case MovingType.sinus:
                gameObject.GetComponent<Rigidbody2D>().position = new Vector2(gameObject.GetComponent<Rigidbody2D>().position.x - movementSpeed, Mathf.Sin(Time.frameCount / 10f));
                break;
            default:
                break;
        }
        level = (int)((maxHealth + moneyForKilling) / (movementSpeed + givenDamage));
        Debug.Log("Level: " + level);
    }

    public void ChangeSprite()
    {
        var T = UnityEngine.Random.Range(1, 10);
        if (T % 2 == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = korp1;

            gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().sprite = el1;
            gameObject.transform.Find("Add3").GetComponent<SpriteRenderer>().sprite = el2;
            gameObject.transform.Find("Add5").GetComponent<SpriteRenderer>().sprite = el3;
        }
        if (T % 3 == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = korp2;

            gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().sprite = el1;
            gameObject.transform.Find("Add2").GetComponent<SpriteRenderer>().sprite = el2;
            gameObject.transform.Find("Add4").GetComponent<SpriteRenderer>().sprite = el3;
        }
        if (T % 5 == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = korp3;

            gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().sprite = el1;
            gameObject.transform.Find("Add2").GetComponent<SpriteRenderer>().sprite = el2;
            gameObject.transform.Find("Add4").GetComponent<SpriteRenderer>().sprite = el3;
        }
        
    }

    public void AdjustEnemy(float health, float speed, float damage, MovingType type, float money)
    {
        maxHealth = health;
        health = maxHealth;
        movementSpeed = speed;
        givenDamage = damage;
        moneyForKilling = money;
        movingType = type;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        ChangeSprite();
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
