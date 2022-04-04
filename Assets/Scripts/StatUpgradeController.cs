using UnityEngine;

public class StatUpgradeController : MonoBehaviour
{
    public SaveManager saveManager;
    public int rateLevel;
    public int speedLevel;
    public int healthLevel;
    
    public void FireRateUpgrade()
    {
        var cost = (rateLevel + 2) * 1;
        if (PlayerStats.coins >= cost && rateLevel < 3)
        {
            PlayerStats.coins -= cost;
            PlayerStats.fireRate -= 0.25f;
            rateLevel++;
            saveManager.SaveGame();
        }
    }

    public void HealthUpgrade()
    {
        var cost = (healthLevel + 2) * 2;
        if (PlayerStats.coins >= cost && healthLevel < 3)
        {
            PlayerStats.coins -= cost;
            PlayerStats.health++;
            healthLevel++;
            saveManager.SaveGame();
        }
    }

    public void MovementSpeedUpgrade()
    {
        var cost = (speedLevel + 2) * 3;
        if (PlayerStats.coins >= cost && speedLevel < 3 )
        {
            PlayerStats.coins -= cost;
            PlayerStats.moveSpeed *= 1.20f;
            speedLevel++;
            saveManager.SaveGame();
        }
    }

    public void DoubleFireUpgrade()
    {
        var cost = 1;
        if (PlayerStats.coins >= cost && !PlayerStats.isDoubleFireActive)
        {
            PlayerStats.coins -= cost;
            PlayerStats.isDoubleFireActive = true;
            saveManager.SaveGame();
        }
    }
}