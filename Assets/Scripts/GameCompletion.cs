using UnityEngine;
using TMPro; // For TextMesh Pro
using UnityEngine.SceneManagement; // For loading the main menu

public class GameCompletion : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script
    public TextMeshProUGUI completionMessage; // Reference to the TextMeshPro UI component
    public float delayBeforeMenu = 3f; // Delay before going back to the menu

    private bool gameCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameCompleted)
        {
            CompleteGame();
        }
    }

    public void CompleteGame()
    {
        gameCompleted = true;
        // Stop the timer
        timer.StopTimer();
        // Display the final message with the remaining time
        DisplayCompletionMessage();
        // Wait for a few seconds before returning to the main menu
        Invoke("ReturnToMainMenu", delayBeforeMenu);
    }

    void DisplayCompletionMessage()
    {
        // Get the remaining time from the Timer script
        float remainingTime = timer.GetRemainingTime();

        // Convert remaining time to minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // Update the TextMeshPro component with the final message
        completionMessage.text =
            $"You have Escaped the Dungeon!\nYour remaining time is {minutes} min {seconds} sec";

        // Make the message visible
        completionMessage.gameObject.SetActive(true);
    }

    void ReturnToMainMenu()
    {
        // Load the "Main Menu" scene
        SceneManager.LoadScene(0);
    }
}
