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
    public float health;
    protected int level;
    protected int prevLevel;


    //Use this for initialization
    void Start () {
        health = maxHealth;
        level = 0;
        prevLevel = 0;
        RngLook();
        SetToColor(Color.white);
        AdjustToLevel();
        RngLook();
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
        prevLevel = level;
        level = (int)((maxHealth + moneyForKilling) / (movementSpeed + givenDamage));
        //Debug.Log("Level: " + level);
        if (prevLevel != level)
        {
            AdjustToLevel();
            RngLook();
            ChangeSprite();
        }
        
    }
    public void RngLook()
    {
        switch(UnityEngine.Random.Range(1, 3)) 
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = korp1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = korp2;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = korp3;
                break;
            default:
                break;
        }
    }
    public void ChangeSprite()
    {
        var T = UnityEngine.Random.Range(1, 35);
        if (T % 2 == 0)
        {
            gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().sprite = el1;
            gameObject.transform.Find("Add3").GetComponent<SpriteRenderer>().sprite = el2;
            gameObject.transform.Find("Add5").GetComponent<SpriteRenderer>().sprite = el3;
        }
        if (T % 3 == 0)
        {
            gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().sprite = el1;
            gameObject.transform.Find("Add2").GetComponent<SpriteRenderer>().sprite = el2;
            gameObject.transform.Find("Add4").GetComponent<SpriteRenderer>().sprite = el3;
        }
        if (T % 5 == 0)
        {
            gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().sprite = el1;
            gameObject.transform.Find("Add2").GetComponent<SpriteRenderer>().sprite = el2;
            gameObject.transform.Find("Add4").GetComponent<SpriteRenderer>().sprite = el3;
        }
        
    }

    public void AdjustToLevel()
    {
        int t = level % 5;
        switch (t)
        {
            case 0:
                SetToColor(UnityEngine.Random.ColorHSV());
                SetKorpColor(UnityEngine.Random.ColorHSV());
                break;
            case 1:
                SetToColor(UnityEngine.Random.ColorHSV());
                SetKorpColor(UnityEngine.Random.ColorHSV());
                break;
            case 2:
                SetToColor(UnityEngine.Random.ColorHSV());
                SetKorpColor(UnityEngine.Random.ColorHSV());
                break;
            case 3:
                SetToColor(UnityEngine.Random.ColorHSV());
                SetKorpColor(UnityEngine.Random.ColorHSV());
                break;
            case 4:
                SetToColor(UnityEngine.Random.ColorHSV());
                SetKorpColor(UnityEngine.Random.ColorHSV());
                break;
            default:
                break;
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

    protected void SetToColor(Color c)
    {
        gameObject.transform.Find("Add1").GetComponent<SpriteRenderer>().color = c;
        gameObject.transform.Find("Add2").GetComponent<SpriteRenderer>().color = c;
        gameObject.transform.Find("Add3").GetComponent<SpriteRenderer>().color = c;
        gameObject.transform.Find("Add4").GetComponent<SpriteRenderer>().color = c;
        gameObject.transform.Find("Add5").GetComponent<SpriteRenderer>().color = c;
    }

    protected void SetKorpColor(Color c)
    {
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }
}
