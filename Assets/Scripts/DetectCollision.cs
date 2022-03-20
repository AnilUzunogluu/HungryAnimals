using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public static int killCount;
    public GameObject coin;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.coins++;
        killCount++;
        var coinPos = other.transform.position;
        coinPos.y += 2;
        Instantiate(coin, coinPos, coin.transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
