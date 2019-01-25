using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    private List<GameObject> enemies;

	// Use this for initialization
	void Start () {
        enemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var enemy in enemies)
        {
            if (enemy.GetHealth() <= 0)
            {

            }
        }
	}

    public List<GameObject> GetEnemies()
    {
        return null;
    }
}
