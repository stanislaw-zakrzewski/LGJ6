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
    float SpawnCooldown = 1;
    float SpawnTime = 0;
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

        SpawnTime += Time.deltaTime;
        if (enemies.Count < enemiesLimit && SpawnTime > SpawnCooldown)
        {
            SpawnTime = 0;
            AdjustSpawn(PlayerPrefs.GetFloat("traveledDistance"));
        }
    }

    public List<GameObject> GetEnemies()
    {
        return enemies;
    }

    private void AdjustSpawn(float distance)
    {
        m = (int)((3 + distance * distance) / 10f);
        
        float ss = 1f / (1f + Mathf.Pow(2.718f, -distance / 10000f))*1000;
        s = Random.Range(10, 10 + ss) / 10000f;

        h = 10 + distance / s;
                    
        Spawn(h, s, d, EnemyBase.MovingType.linear, m);
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
