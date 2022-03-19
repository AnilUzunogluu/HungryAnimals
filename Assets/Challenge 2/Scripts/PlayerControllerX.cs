using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeMin = 1f;
    private float time;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && time > timeMin)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            time = 0f;
        }
    }
}
