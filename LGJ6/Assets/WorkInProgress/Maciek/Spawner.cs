using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int enemiesLimit;
    public GameObject enemyType1;
    public GameObject enemyType2;
    public GameObject house;
    private List<GameObject> enemies;

    private float baseHealth = 30f;
    private float baseSpeed = 0.01f;
    private float baseDamage = 20f;
    private float baseMoney = 1f;

    float h;
    float s;
    float d;
    float m;
    // Use this for initialization
    void Start()
    {
        enemies = new List<GameObject>();
        h = baseHealth;
        s = baseSpeed;
        d = baseDamage;
        m = baseMoney;
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> toRemove = new List<GameObject>();
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<EnemyBase>().GetHealth() <= 0f)
            {
                house.gameObject.GetComponent<House>().AddMoney(enemy.gameObject.GetComponent<EnemyBase>().moneyForKilling);
                Destroy(enemy.gameObject);
                toRemove.Add(enemy);
            }
        }
        foreach (var enemy in toRemove)
        {
            enemies.Remove(enemy);
        }
        if (enemies.Count < enemiesLimit)
        {
            AdjustSpawn(PlayerPrefs.GetFloat("traveledDistance"));
        }
    }

    public List<GameObject> GetEnemies()
    {
        return enemies;
    }

    private void AdjustSpawn(float distance)
    {
        
        if (((int)distance % 10) == 0)
        {
            h += Mathf.Log10(distance);
            s += 0.0005f;
            //d += 0.05f;
            m += 0.05f;
        }
        
        if (Random.Range(1, 1000) % 100 == 0)
        {               
            Spawn(h, s, d, EnemyBase.MovingType.linear, m);
        }   
    }

    private void Spawn(float health, float speed, float damage, EnemyBase.MovingType type, float money)
    {
        GameObject enem;
        if (Time.frameCount % 5 == 0)
        {
            enem = Instantiate(enemyType1);
        } else {
            enem = Instantiate(enemyType2);
        }        
        enem.gameObject.transform.position = transform.position;
        enem.gameObject.transform.SetParent(transform); 
        //enem.gameObject.GetComponent<Rigidbody2D>().position = transform.position;
        
        enem.gameObject.GetComponent<EnemyBase>().AdjustEnemy(health, speed, damage, type, money);
        enemies.Add(enem);
    }
}
