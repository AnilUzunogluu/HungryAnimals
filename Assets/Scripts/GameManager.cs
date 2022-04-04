using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera gameCamera;
    private UIManager uiScript;
    public static bool isGameStarted;
    private static bool isGameOver;
    private Animator cameraAnimation;
    public GameObject player;
    private PlayerController playerController;
    private SaveManager saveManager;

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
    }

    public void SetGameOver(bool b)
    {
        isGameStarted = !b;
        isGameOver = b;
        if (b)
        {
            GameOver();
        }
    }
}