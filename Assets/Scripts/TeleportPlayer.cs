using System.Collections;
using UnityEngine;
using TMPro;  // Needed for TextMesh Pro UI components

public class TeleportPlayer : MonoBehaviour
{
    public Transform player;              // Player's current position
    public Transform destination;         // Teleport destination
    public GameObject playerg;            // Reference to the player GameObject
    public TextMeshProUGUI messageUI;     // Reference to the TextMesh Pro UI Text component for messages

    private PlayerCoins playerCoins;      // Reference to the PlayerCoins script

    private void Start()
    {
        // Ensure the message UI is initially hidden
        if (messageUI != null)
        {
            messageUI.text = "";
        }
        else
        {
            Debug.LogError("Message UI TextMeshProUGUI is not assigned!");
        }

        // Check if the player GameObject and PlayerCoins script are assigned
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
            // Check if playerCoins is assigned
            if (playerCoins == null)
            {
                Debug.LogError("PlayerCoins script is not assigned or found!");
                return;
            }

            // Check if playerg and destination are assigned
            if (playerg == null || destination == null)
            {
                Debug.LogError("Player GameObject or Destination Transform is not assigned!");
                return;
            }

            // Access the number of coins the player currently has
            int currentCoins = playerCoins.currentCoins;

            if (currentCoins % 2 == 0)  // If coins are even
            {
                // Teleport the player
                playerg.SetActive(false);
                player.position = destination.position;
                playerg.SetActive(true);

                // Hide the UI message if it was displayed previously
                if (messageUI != null)
                {
                    messageUI.text = "";
                }
            }
            else  // If coins are odd
            {
                // Show the message in the UI
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
        // Ensure the message UI is not null
        if (messageUI != null)
        {
            // Set the message and make it visible
            messageUI.text = message;

            // Wait for the specified duration
            yield return new WaitForSeconds(duration);

            // Hide the message after the duration
            messageUI.text = "";
        }
        else
        {
            Debug.LogError("Message UI TextMeshProUGUI is not assigned!");
        }
    }
}
