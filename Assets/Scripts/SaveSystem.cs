using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private StatUpgradeController upgradeController;
    private PlayerController playerController;
    private float timeCount;
    private float saveFrequency = 5f;

    private void Start()
    {
        upgradeController = GetComponent<StatUpgradeController>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Saves the game automatically in set periods.
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= saveFrequency)
        {
            SaveGame();
            Debug.Log("Game Saved!");
            timeCount = 0f;
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("FireRate", PlayerStats.fireRate);
        PlayerPrefs.SetInt("rateLevel", upgradeController.rateLevel);
        
        PlayerPrefs.SetInt("TotalHealth", PlayerStats.health);
        PlayerPrefs.SetInt("healthLevel", upgradeController.healthLevel);
        
        PlayerPrefs.SetFloat("MoveSpeed", PlayerStats.moveSpeed);
        PlayerPrefs.SetInt("speedLevel", upgradeController.speedLevel);
        
        PlayerPrefs.SetInt("DoubleFire", 1);
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
        if (PlayerPrefs.GetInt("DoubleFire") == 1)
        {
            PlayerStats.isDoubleFireActive = true;
        }
    }
}
