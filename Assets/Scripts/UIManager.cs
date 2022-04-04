using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject upgradeMenuImages;
    public Text health;
    public Text coin;
    public Text gameOver;
    public Button play;
    public Button upgrades;
    public Button quit;


    private void Update()
    {
        health.text = PlayerController.currentHealth + "";
        coin.text = $"Coins: {PlayerStats.coins}";
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
        upgradeMenu.gameObject.SetActive(true);
        upgradeMenuImages.gameObject.SetActive(true);
        DisableMainMenu();
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
}