using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour
{
    public Text damage;
    public Text cooldown;
    public Text range;
    public Text velocity;
    public Text cost;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        PlayerPrefs.SetFloat("damage", 0);
        PlayerPrefs.SetFloat("cooldown", 0);
        PlayerPrefs.SetFloat("range", 0);
        PlayerPrefs.SetFloat("velocity", 0);
        PlayerPrefs.SetFloat("cost", 0);
        ClearStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("damage") != 0) damage.text = PlayerPrefs.GetFloat("damage").ToString();
        if (PlayerPrefs.GetFloat("cooldown") != 0) cooldown.text = PlayerPrefs.GetFloat("cooldown").ToString("F2");
        if (PlayerPrefs.GetFloat("range") != 0) range.text = PlayerPrefs.GetFloat("range").ToString();
        if (PlayerPrefs.GetFloat("velocity") != 0) velocity.text = PlayerPrefs.GetFloat("velocity").ToString();
        if (PlayerPrefs.GetFloat("cost") != 0) cost.text = ((int)PlayerPrefs.GetFloat("cost")).ToString() + "$";
    }

    private void ClearStats()
    {
        damage.text = "";
        cooldown.text = "";
        range.text = "";
        velocity.text = "";
        cost.text = "";
    }
}
