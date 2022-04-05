using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera gameCamera;
    private UIManager uiScript;
    private SaveManager saveManager;
    private Animator cameraAnimation;
    public GameObject player;
    private PlayerController playerController;
    public StatUpgradeController upgradeController;

    public static bool isGameStarted;
    private static bool isGameOver;
    private int gameWinCondition = 200;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GetComponent<SaveManager>();
        uiScript = gameObject.GetComponent<UIManager>();
        playerController = player.GetComponent<PlayerController>();
        cameraAnimation = gameCamera.GetComponent<Animator>();
        cameraAnimation.enabled = false;
        saveManager.LoadGame();
    }

    public void PlayButtonClick()
    {
        DetectCollision.killCount = 0;
        isGameOver = false;
        uiScript.DisableGameOver();
        uiScript.DisableMainMenu();
        isGameStarted = true;
        player.transform.position = new Vector3(0, 0, -2.8f);
        playerController.Start();
        cameraAnimation.enabled = true;
        cameraAnimation.Play(0);
        saveManager.LoadGame();
    }

    private void GameOver()
    {
        uiScript.CallGameOver();
        uiScript.CallMainMenu();
        saveManager.SaveGame();
    }

    public void UpgradesButtonClick()
    {
        uiScript.CallUpgradesMenu();
        uiScript.DisableGameOver();
    }

    public void BackToMenuClick()
    {
        uiScript.CallMainMenu();
    }

    public void QuitGameButtonClick()
    {
        saveManager.SaveGame();
        Application.Quit();
    }

    public void ResetButtonClick()
    {
        PlayerPrefs.DeleteAll();
        upgradeController.rateLevel = 0;
        upgradeController.speedLevel = 0;
        upgradeController.healthLevel = 0;
        upgradeController.doubleFireLevel = 0;
        PlayerStats.coins = 0;
        PlayerStats.health = 3;
        PlayerStats.moveSpeed = 15f;
        PlayerStats.fireRate = 1f;
        PlayerStats.isDoubleFireActive = false;
        saveManager.SaveGame();
    }

    public void SetGameOver(bool b)
    {
        if (DetectCollision.killCount < gameWinCondition)
        {
            isGameStarted = !b;
            isGameOver = b;
            if (b)
            {
                GameOver();
            }
        }
        else
        {
            isGameStarted = !b;
            isGameOver = b;
            saveManager.SaveGame();
            uiScript.WinScreen();
        }
        
    }
}