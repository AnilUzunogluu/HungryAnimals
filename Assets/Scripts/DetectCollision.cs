using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public static int killCount;
    public GameObject coin;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.coins++;
        Actions.PlayerGotMoney?.Invoke();
        killCount++;
        var coinPos = other.transform.position;
        coinPos.y += 2;
        Instantiate(coin, coinPos, coin.transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
