using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCoins playerCoins = other.GetComponent<PlayerCoins>();
            if (playerCoins != null)
            {
                playerCoins.AddCoins(coinValue);
                AudioManager.Instance.PlayCoinPickupSound(); 
                Destroy(gameObject);
            }
        }
    }
}
