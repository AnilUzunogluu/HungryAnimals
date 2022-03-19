using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    public float horizontalInput;
    private float xRange = 20f;
    public GameObject projectile;
    private float rateCount;
    public static int currentHealth;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        currentHealth = PlayerStats.health;
    }

// Update is called once per frame
    private void Update()
    {
        if (GameManager.isGameStarted)
        {
            rateCount += Time.deltaTime;
            PlayerMovement();
            Shoot();
        }
        
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * (PlayerStats.moveSpeed * Time.deltaTime)));
        if (transform.position.x < -xRange)
        {
            var position = transform.position;
            position = new Vector3(-xRange, position.y, position.z);
            transform.position = position;
        }
        else if (transform.position.x > xRange)
        {
            var position = transform.position;
            position = new Vector3(xRange, position.y, position.z);
            transform.position = position;
        }
    }

    private void Shoot()
    {
        if (PlayerStats.isDoubleFireActive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && rateCount > PlayerStats.fireRate)
            {
                var position = transform.position;
                var setoff = -0.75f;
                var left = new Vector3(position.x - setoff, position.y, position.z);
                var right = new Vector3(position.x + setoff, position.y, position.z);
                Instantiate(projectile, left, Quaternion.identity);
                Instantiate(projectile, right, Quaternion.identity);
                rateCount = 0f;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && rateCount > PlayerStats.fireRate)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                rateCount = 0f;
            }
        }
    }

    private void IsGameOver()
    {
        if (currentHealth <= 0)
        {
            gameManager.SetGameOver(true);
        }
    }

    public void Damage()
    {
        currentHealth--; 
        currentHealth = currentHealth < 0 ? currentHealth = 0 : currentHealth;
        IsGameOver();
    }
}