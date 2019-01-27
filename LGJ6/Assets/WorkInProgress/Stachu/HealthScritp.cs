using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScritp : MonoBehaviour
{
    public GameObject healthbar;
    private EnemyBase enemy;
    // Use this for initialization
    void Start()
    {
        enemy = gameObject.GetComponent<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.localScale = new Vector3(enemy.health / enemy.maxHealth, .5f, 1);
    }
}
