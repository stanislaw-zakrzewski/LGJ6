using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider slider;
    public Text currentHealthText;
    public Text maxHealthText;
    public House house;
    public Button upgradeButton;
    public Text upgradeButtonText;

    private float maxHealth;
    private float health;
    private int healthLevel;
    private int nextHealthDifference = 500;
    private int nextPriceDifference = 100;

    // Use this for initialization
    void Start()
    {
        health = 5;
        maxHealth = 10;
        upgradeButton.onClick.AddListener(() => UpdateHealth());
        healthLevel = 1;
        upgradeButtonText.text = (nextPriceDifference * healthLevel).ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat("health") != health)
        {
            health = PlayerPrefs.GetFloat("health");
            slider.value = health / maxHealth;
            currentHealthText.text = ((int)health).ToString() + " / " + ((int)maxHealth).ToString();
            maxHealthText.text = ((int)maxHealth + nextHealthDifference).ToString();
        }
        if (PlayerPrefs.GetFloat("maxHealth") != maxHealth)
        {
            maxHealth = PlayerPrefs.GetFloat("maxHealth");
            slider.value = health / maxHealth;
            currentHealthText.text = ((int)health).ToString() + " / " + ((int)maxHealth).ToString();
            maxHealthText.text = ((int)maxHealth + nextHealthDifference).ToString();
        }
    }

    void UpdateHealth()
    {
        if(PlayerPrefs.GetFloat("money") > healthLevel * nextPriceDifference)
        {
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - healthLevel * nextPriceDifference);
            healthLevel++;
            upgradeButtonText.text = (nextPriceDifference * healthLevel).ToString() + "$";
            house.maxHealth = house.maxHealth + nextHealthDifference;
            PlayerPrefs.SetFloat("health", house.maxHealth);
            house.health = house.maxHealth;
            PlayerPrefs.SetFloat("maxHealth", house.maxHealth);
        }
    }
}
