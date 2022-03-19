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

    // game over, oyun başladı mı, upgrade sayfası gelsin mi, 
    // Start is called before the first frame update
    void Start()
    {
        uiScript = gameObject.GetComponent<UIManager>();
        playerController = player.GetComponent<PlayerController>();
        cameraAnimation = gameCamera.GetComponent<Animator>();
        cameraAnimation.enabled = false;
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
    }

    private void GameOver()
    {
        uiScript.CallGameOver();
        uiScript.CallMainMenu();
    }

    public void UpgradesButtonClick()
    {
        uiScript.CallUpgradesMenu();
        uiScript.DisableGameOver();
        // uiScript.DisableGameOver();
    }

    public void BackToMenuClick()
    {
        uiScript.CallMainMenu();
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