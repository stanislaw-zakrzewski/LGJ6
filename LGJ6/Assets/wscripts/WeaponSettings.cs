using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSettings {
    // weapon
    public float ReloadTime { get; set; }
    public float Range { get; set; }

    // projectile
    public float Damage { get; set; }
    public float Speed { get; set; }

    private float maxRange = 10;
    private float minRange = 1;

    public WeaponSettings(float level)
    {
        // level = range * damage / reloadtime + speed
        Speed = Random.Range(level/10, level);
        float myLevel = level - Speed;
        Range = Random.Range(minRange, maxRange);
        myLevel /= Range;
        ReloadTime = 1f / Random.Range(0.5f, 10);
        Damage = myLevel * ReloadTime;
    }
}
