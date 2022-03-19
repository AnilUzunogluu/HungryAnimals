using System;
using UnityEngine;

public class DestroyRunAway : MonoBehaviour
{
    private float topBorder = 30;
    private float bottomBorder = -10;
    private PlayerController playerController;

    private void Start()
    {
        var player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z > topBorder)
        {
            Destroy(gameObject);
        }else if (transform.position.z < bottomBorder)
        {
            playerController.Damage();
            Destroy(gameObject);
        }
    }
}
