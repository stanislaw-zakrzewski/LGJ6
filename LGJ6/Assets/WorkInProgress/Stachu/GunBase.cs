using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour {
    public GameObject bulletType;
    public GameObject enemyArea;

    private List<GameObject> activeEnemies;

	void Start () {
        activeEnemies = new List<GameObject>();
        
	}
	
	void Update () {
		
	}

    void SetActiveEnemies()
    {
        //from spawner get enemy list
    }
}
