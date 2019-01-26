using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int enemiesLimit;
    public GameObject enemy;
    public GameObject house;
    private List<GameObject> enemies;

    // Use this for initialization
    void Start()
    {
        enemies = new List<GameObject>();
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
               
        if (Random.Range(1, 1000) % 2 == 0)
        {
            Spawn();
        }   
    }

    private void Spawn()
    {
        var enem = Instantiate(enemy);
        enem.gameObject.GetComponent<Rigidbody2D>().position = transform.position;
        enemies.Add(enem);
    }
}
