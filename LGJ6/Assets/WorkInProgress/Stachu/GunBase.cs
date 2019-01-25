﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public GameObject bulletType;
    public GameObject spawner;
    public float range;
    public float cooldown;
    public float damage;
    public float velocity;

    private List<GameObject> activeEnemies;
    private List<GameObject> projectiles;
    private GameObject target;

    void Start()
    {
        SetActiveEnemies();
        InvokeRepeating("SetActiveEnemies", 0, 0.1f);
        InvokeRepeating("ShootProjetile", 0, cooldown);
    }

    void Update()
    {
        if(target == null)
        {
            SetActiveEnemies();
        }
        activeEnemies = activeEnemies.Where(e => e != null).ToList();
    }

    void ShootProjectile()
    {
        if (target != null)
        {
            GameObject pom = Instantiate(bulletType);
            pom.GetComponent<ProjectileBase>().damage = damage;
            pom.GetComponent<ProjectileBase>().velocity = velocity;
            pom.GetComponent<ProjectileBase>().target = target;
            pom.GetComponent<ProjectileBase>().gun = this;
        }
    }

    void SetActiveEnemies()
    {
        activeEnemies = new List<GameObject>();
        foreach (var enemy in spawner.GetComponent<Spawner>().GetEnemies())
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= range)
            {
                activeEnemies.Add(enemy);
            }
        }
        if (activeEnemies.Count == 0)
        {
            target = activeEnemies[0];
        }
        else if (activeEnemies.Count > 1)
        {
            activeEnemies.OrderBy(e => Vector2.Distance(e.transform.position, transform.position));
            target = activeEnemies[0];
        }
    }

    public void ReturnProjectile(GameObject projectileToReturn)
    {
        Destroy(projectileToReturn);
        projectiles.Remove(projectileToReturn);
    }
}