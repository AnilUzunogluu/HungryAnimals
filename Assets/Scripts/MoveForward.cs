using System;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    private void Update()
    {
     Move();   
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
    //
    // private void OnTriggerEnter(Collider other)
    // {
    //     Destroy(gameObject);
    // }
}
