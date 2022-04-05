using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public StatUpgradeController upgradeController;
    public PlayerController playerController;
    private float timeCount;
    private float saveFrequency = 5f;

    public void SaveGame()
    {
        Debug.Log("Game Saved!");
        
        PlayerPrefs.SetFloat("FireRate", PlayerStats.fireRate);
        PlayerPrefs.SetInt("rateLevel", upgradeController.rateLevel);
        
        PlayerPrefs.SetInt("TotalHealth", PlayerStats.health);
        PlayerPrefs.SetInt("healthLevel", upgradeController.healthLevel);
        
        PlayerPrefs.SetFloat("MoveSpeed", PlayerStats.moveSpeed);
        PlayerPrefs.SetInt("speedLevel", upgradeController.speedLevel);
        
        PlayerPrefs.SetInt("DoubleFire", PlayerStats.isDoubleFireActive? 1 : 0);
        PlayerPrefs.SetInt("DoubleFireLevel", upgradeController.doubleFireLevel);

        PlayerPrefs.SetInt("Coins", PlayerStats.coins);
    }

    public void LoadGame()
    {
        playerController.currentHealth = PlayerPrefs.GetInt("TotalHealth", 3);
        playerController.currentMoveSpeed = PlayerPrefs.GetFloat("MoveSpeed", 15);
        playerController.currentFireRate = PlayerPrefs.GetFloat("FireRate", 1f);
        PlayerStats.coins = PlayerPrefs.GetInt("Coins", 0);

        upgradeController.rateLevel = PlayerPrefs.GetInt("rateLevel", 0);
        upgradeController.speedLevel = PlayerPrefs.GetInt("speedLevel", 0);
        upgradeController.healthLevel = PlayerPrefs.GetInt("healthLevel", 0);
        upgradeController.doubleFireLevel = PlayerPrefs.GetInt("DoubleFireLevel", 0);
        if (PlayerPrefs.GetInt("DoubleFire") == 1)
        {
            PlayerStats.isDoubleFireActive = true;
        }
    }
}
