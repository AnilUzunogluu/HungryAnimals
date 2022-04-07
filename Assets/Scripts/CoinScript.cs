using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed);
        Destroy(gameObject, 0.75f);
    }
}
