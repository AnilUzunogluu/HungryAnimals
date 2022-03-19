using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public static int killCount;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.coins++;
        killCount++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
