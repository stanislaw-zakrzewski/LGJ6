using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour {
       
	// Use this for initialization
	void Start () {
        //GetComponent<Text>().text = PlayerPrefs.GetFloat("startingMoney").ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = ((int)PlayerPrefs.GetFloat("money")).ToString() + "$";

	}
}
