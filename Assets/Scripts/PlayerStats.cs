using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerStats : MonoBehaviour
{
    //holds all of the player stats
    public static float moveSpeed = 15;
    public static float fireRate = 1f;
    public static int health = 3;
    public static int coins;
    public static bool isDoubleFireActive;
}
