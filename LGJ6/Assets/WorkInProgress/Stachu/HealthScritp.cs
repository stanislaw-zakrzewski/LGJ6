using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScritp : MonoBehaviour
{
    public GameObject healthbar;
    private EnemyBase enemy;

    void Start()
    {
        enemy = gameObject.GetComponent<EnemyBase>();
    }
    
    void Update()
    {
        healthbar.transform.localScale = new Vector3(enemy.health / enemy.maxHealth, .5f, 1);
    }
}
