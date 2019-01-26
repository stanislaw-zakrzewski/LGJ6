using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : EnemyBase {

	// Use this for initialization
	void Start () {
        maxHealth /= 3;
        movementSpeed *= 1.5f;
        givenDamage /= 1.5f;
        moneyForKilling /= 1.2f;
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
