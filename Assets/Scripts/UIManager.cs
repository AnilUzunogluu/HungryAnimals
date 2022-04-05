using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject upgradeMenuImages;
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

    public Button play;
    public Button upgrades;
    public Button quit;
    
    public Image coinImage;

    private void Update()
    {
        health.text = playerController.currentHealth + "";
        coin.text = $"{PlayerStats.coins}";
    }

    public void CallMainMenu()
    {
        upgradeMenu.gameObject.SetActive(false);
        upgradeMenuImages.gameObject.SetActive(false);

        play.gameObject.SetActive(true);
        upgrades.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

    public void DisableMainMenu()
    {
        play.gameObject.SetActive(false);
        upgrades.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void CallUpgradesMenu()
    {
        PrintUpgradeCosts();
        upgradeMenu.gameObject.SetActive(true);
        upgradeMenuImages.gameObject.SetActive(true);
        DisableMainMenu();
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
        coin.gameObject.SetActive(false);
        coinImage.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
        finalScore.text = $"Your Final\nScore Was:\n{DetectCollision.killCount}";
        finalScore.gameObject.SetActive(true);
    }
}