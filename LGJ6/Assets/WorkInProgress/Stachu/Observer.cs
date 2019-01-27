using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Observer : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        //If something was hit, the RaycastHit2D.collider will not be null.
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.transform.name);
            if(hit.collider.gameObject.GetComponent<GunBase>())
            {
                var g = hit.collider.gameObject.GetComponent<GunBase>();
                PlayerPrefs.SetFloat("damage",g.damage);
                PlayerPrefs.SetFloat("cooldown",g.cooldown);
                PlayerPrefs.SetFloat("range",g.range);
                PlayerPrefs.SetFloat("velocity",g.velocity);
                PlayerPrefs.SetFloat("cost",g.cost);
            }
        }
    }
}
