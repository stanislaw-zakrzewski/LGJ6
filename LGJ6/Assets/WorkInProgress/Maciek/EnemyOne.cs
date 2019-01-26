using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : EnemyBase {

	// Use this for initialization
	void Start () {
        maxHealth *= 3;
        movementSpeed /= 2;
        givenDamage *= 2.5f;
        moneyForKilling *= 1.2f;
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
