using System.Collections;
using UnityEngine;
using TMPro;  
public class TeleportPlayer : MonoBehaviour
{
    public Transform player;              
    public Transform destination;         
    public GameObject playerg;           
    public TextMeshProUGUI messageUI;     

    private PlayerCoins playerCoins;      

    private void Start()
    {
       
        if (messageUI != null)
        {
            messageUI.text = "";
        }
        else
        {
            Debug.LogError("Message UI TextMeshProUGUI is not assigned!");
        }

        if (player != null)
        {
            playerCoins = player.GetComponent<PlayerCoins>();
            if (playerCoins == null)
            {
                Debug.LogError("PlayerCoins script not found on player GameObject!");
            }
        }
        else
        {
            Debug.LogError("Player Transform is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerCoins == null)
            {
                Debug.LogError("PlayerCoins script is not assigned or found!");
                return;
            }

           
            if (playerg == null || destination == null)
            {
                Debug.LogError("Player GameObject or Destination Transform is not assigned!");
                return;
            }

            int currentCoins = playerCoins.currentCoins;

            if (currentCoins % 2 == 0) 
            {
                playerg.SetActive(false);
                player.position = destination.position;
                playerg.SetActive(true);

                if (messageUI != null)
                {
                    messageUI.text = "";
                }
            }
            else 
            {
                if (messageUI != null)
                {
                    StartCoroutine(ShowMessageForDuration("The Magical Rock Doesn't Like ODD Numbers", 2.5f));
                }
                else
                {
                    Debug.LogError("Message UI TextMeshProUGUI is not assigned!");
                }
            }
        }
    }

    private IEnumerator ShowMessageForDuration(string message, float duration)
    {
        if (messageUI != null)
        {
            messageUI.text = message;
            yield return new WaitForSeconds(duration);

            messageUI.text = "";
        }
        else
        {
            Debug.LogError("Message UI TextMeshProUGUI is not assigned!");
        }
    }
}
