using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip coinSound;
    private void OnEnable()
    {
        Actions.PlayerGotMoney += OnPlayerGotMoney;
    }

    private void OnDisable()
    {
        Actions.PlayerGotMoney -= OnPlayerGotMoney;
    }

    private void OnPlayerGotMoney()
    {
        audioSource.PlayOneShot(coinSound);
    }
}
