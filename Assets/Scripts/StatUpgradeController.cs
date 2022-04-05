using UnityEngine;

public class StatUpgradeController : MonoBehaviour
{
    public SaveManager saveManager;
    public int maxUpgradeLevel = 3;
    public int rateLevel;
    public int rateCost;
    public int speedLevel;
    public int speedCost;
    public int healthLevel;
    public int healthCost;
    public int doubleFireLevel;
    public int doubleFireCost;
    
    public void FireRateUpgrade()
    {
        if (PlayerStats.coins >= rateCost && rateLevel < maxUpgradeLevel)
        {
            PlayerStats.coins -= rateCost;
            PlayerStats.fireRate -= 0.25f;
            rateLevel++;
            saveManager.SaveGame();
        }
    }

    public void HealthUpgrade()
    {
        if (PlayerStats.coins >= healthCost && healthLevel < maxUpgradeLevel)
        {
            PlayerStats.coins -= healthCost;
            PlayerStats.health++;
            healthLevel++;
            saveManager.SaveGame();
        }
    }

    public void MovementSpeedUpgrade()
    {
        if (PlayerStats.coins >= speedCost && speedLevel < maxUpgradeLevel )
        {
            PlayerStats.coins -= speedCost;
            PlayerStats.moveSpeed *= 1.20f;
            speedLevel++;
            saveManager.SaveGame();
        }
    }

    public void DoubleFireUpgrade()
    {
        if (PlayerStats.coins >= doubleFireCost && !PlayerStats.isDoubleFireActive)
        {
            PlayerStats.coins -= doubleFireCost;
            PlayerStats.isDoubleFireActive = true;
            doubleFireLevel = maxUpgradeLevel;
            saveManager.SaveGame();
        }
    }

    public void CalcCost()
    {
        rateCost = (rateLevel + 2) * 10;
        healthCost = (healthLevel + 2) * 25;
        speedCost = (speedLevel + 2) * 30;
        doubleFireCost = 100;
    }
}