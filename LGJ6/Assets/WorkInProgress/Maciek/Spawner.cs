﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private List<GameObject> enemies;
    public int enemiesLimit;
    public GameObject enemy;

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
            Spawn();
        }
    }

    public List<GameObject> GetEnemies()
    {
        return enemies;
    }

    private void Spawn()
    {
        enemies.Add(Instantiate(enemy));
    }
}
