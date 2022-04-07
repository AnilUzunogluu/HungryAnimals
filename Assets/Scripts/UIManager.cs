using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject upgradeMenuImages;
    public GameObject mainMenu;
    public GameObject uiElements;
    public PlayerController playerController;
    public StatUpgradeController upgradeController;
    
    public Text health;
    public Text coin;
    public Text gameOver;
    public Text winScreen;
    public Text finalScore;
    public Text rateUpgradeText;
    public Text speedUpgradeText;
    public Text healthUpgradeText;
    public Text doubleFireUpgradeText;
    public Text[] upgradesCostText;
    private int[] upgradesCost;
    private int[] upgradesLevel;
    
    public Button quit;

    private void Update()
    {
        health.text = playerController.currentHealth + "";
        coin.text = $"{PlayerStats.coins}";
    }

    public void CallMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

    public void DisableMainMenu()
    {
        mainMenu.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void CallUpgradesMenu()
    {
        PrintUpgradeCosts();
        upgradeMenu.gameObject.SetActive(true);
        upgradeMenuImages.gameObject.SetActive(true);
        DisableMainMenu();
    }

    public void DisableUpgradesMenu()
    {
        upgradeMenu.gameObject.SetActive(false);
        upgradeMenuImages.gameObject.SetActive(false);
    }

    public void PrintUpgradeCosts()
    { 
        upgradeController.CalcCost();
        upgradesCost = new[]
        {
            upgradeController.rateCost, 
            upgradeController.healthCost, 
            upgradeController.speedCost,
            upgradeController.doubleFireCost
        };

        upgradesLevel = new[]
        {
            upgradeController.rateLevel,
            upgradeController.healthLevel,
            upgradeController.speedLevel,
            upgradeController.doubleFireLevel,
        };
        var length = upgradesCost.Length;
        for (int i = 0; i <length ; i++)
        {
            if (upgradesLevel[i] < upgradeController.maxUpgradeLevel)
            {
                upgradesCostText[i].text = upgradesCost[i] + " Gold";
            }
            else
            {
                upgradesCostText[i].text = "Maxed Out!";
            }
        }
    }

    public void CallGameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameOver.text = $"Run Failed!\nAnimals Fed: {DetectCollision.killCount}";
    }

    public void DisableGameOver()
    {
        gameOver.gameObject.SetActive(false);
    }

    public void WinScreen()
    {
        winScreen.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        uiElements.gameObject.SetActive(false);
        finalScore.text = $"Your Final\nScore Was:\n{DetectCollision.killCount}";
        finalScore.gameObject.SetActive(true);
    }
}