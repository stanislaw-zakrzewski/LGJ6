using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    public GameObject map;

    float startX;
    private List<GameObject> maps;
    GameObject g, g2;
    float size;
    void Start () {
        maps = new List<GameObject>();
        g = Instantiate(map);
        maps.Add(g);
        g2 = Instantiate(map);
        startX = g2.transform.position.x;
        size = 2050 / ((Screen.height / 2.0f) / Camera.main.orthographicSize);
        g2.transform.position = g2.transform.position + new Vector3(size, 0,0);
        maps.Add(g2);
        
	}
	
	// Update is called once per frame
	void Update () {
		if (g.transform.position.x < startX - size)
        {
            g.transform.position = g.transform.position + new Vector3(size*2, 0, 0);
        }
        if (g2.transform.position.x < startX - size)
        {
            g2.transform.position = g2.transform.position + new Vector3(size * 2, 0, 0);
        }

        if (g.transform.position.x > startX && g.transform.position.x < g2.transform.position.x)
        {
            g2.transform.position = g2.transform.position - new Vector3(size * 2, 0, 0);
        }
        if (g2.transform.position.x > startX && g2.transform.position.x < g.transform.position.x)
        {
            g.transform.position = g.transform.position - new Vector3(size * 2, 0, 0);
        }
    }

    public void MoveLeft()
    {
        foreach(var m in maps)
        {
            m.transform.position = m.transform.position + new Vector3(.01f, 0, 0);
        }
    }

    public void MoveRight()
    {
        foreach (var m in maps)
        {
            m.transform.position = m.transform.position + new Vector3(-.01f, 0, 0);
        }
    }
}
