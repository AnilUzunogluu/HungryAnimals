using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUpgradeController : MonoBehaviour
{
    public PlayerStats playerStats;

    public int rateLevel;
    public int speedLevel;
    public int healthLevel;

    public void FireRateUpgrade()
    {
        var cost = (rateLevel + 2) * 10;
        if (PlayerStats.coins >= cost && rateLevel < 3)
        {
            PlayerStats.coins -= cost;
            PlayerStats.fireRate -= 0.25f;
            rateLevel++;
        }
    }

    public void HealthUpgrade()
    {
        var cost = (healthLevel + 2) * 25;
        if (PlayerStats.coins >= cost && healthLevel < 3)
        {
            PlayerStats.coins -= cost;
            PlayerStats.health++;
            healthLevel++;
        }
    }

    public void MovementSpeedUpgrade()
    {
        var cost = (speedLevel + 2) * 30;
        if (PlayerStats.coins >= cost && speedLevel < 3 )
        {
            PlayerStats.coins -= cost;
            PlayerStats.moveSpeed *= 1.20f;
            speedLevel++;

        }
    }

    public void DoubleFireUpgrade()
    {
        var cost = 100;
        if (PlayerStats.coins >= cost && !PlayerStats.isDoubleFireActive)
        {
            PlayerStats.coins -= 100;
            PlayerStats.isDoubleFireActive = true;
        }
        
    }
}