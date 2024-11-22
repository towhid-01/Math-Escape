using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class DoorRotationWithCoins : MonoBehaviour
{
    public Transform player;    // Reference to the player's transform
    public float openDistance = 1.0f; // Distance at which the door opens
    public float openAngle = 90.0f; // Angle to rotate the door to open
    public float openSpeed = 2.0f; // Speed of door rotation
    public int requiredCoins = 5; // Number of coins required to open the door
    public TMP_Text promptText; // TextMeshPro UI Text for prompts

    private bool isOpen = false; // Track if the door is open
    private PlayerCoins playerCoins; // Reference to the player's coin collection

    private Quaternion closedRotation; // Store the initial rotation (closed state)
    private Quaternion openRotation; // Store the target rotation (open state)

    void Start()
    {
        // Save the door's original (closed) rotation
        closedRotation = transform.rotation;

        // Calculate the target open rotation (rotate by the open angle on Y-axis)
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);

        // Hide the prompt text initially
        promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Ensure playerCoins reference exists
        if (playerCoins == null) return;

        // Calculate the distance between the player and the door
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // If the player is within the openDistance and the door isn't open yet
        if (distanceToPlayer <= openDistance && !isOpen)
        {
            // Check if the player has enough coins
            if (playerCoins.currentCoins >= requiredCoins)
            {
                // Rotate the door towards the open state
                transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);

                // Check if the door is nearly open (close enough to the target rotation)
                if (Quaternion.Angle(transform.rotation, openRotation) < 1.0f)
                {
                    isOpen = true; // Mark the door as open
                    promptText.gameObject.SetActive(false); // Hide the prompt
                }
            }
            else
            {
                // Show the prompt that more coins are needed
                int coinsNeeded = requiredCoins - playerCoins.currentCoins;
                promptText.text = $"You need {coinsNeeded} more coins to open the door.";
                promptText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCoins = other.GetComponent<PlayerCoins>(); // Get the player's coin script when they enter the trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the prompt when the player leaves the trigger
            promptText.gameObject.SetActive(false);
        }
    }
}
  