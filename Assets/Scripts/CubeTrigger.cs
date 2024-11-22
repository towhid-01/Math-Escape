using System.Collections;
using UnityEngine;
using TMPro;  // Needed for TextMesh Pro UI components

public class CubeTrigger : MonoBehaviour
{
    public TextMeshProUGUI messageUI;      // Reference to the TextMesh Pro UI Text component for messages
    public GameObject player;              // Reference to the player GameObject

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.gameObject == player)
        {
            // Display the message in the UI
            StartCoroutine(ShowMessageForDuration("More coins aren’t always better.", 2.5f));
        }
    }

    private IEnumerator ShowMessageForDuration(string message, float duration)
    {
        // Set the message and make it visible
        messageUI.text = message;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Hide the message after the duration
        messageUI.text = "";
    }
}
