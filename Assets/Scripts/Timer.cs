using UnityEngine;
using TMPro; // For TextMesh Pro

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;       // Reference to the UI Text component for the timer
    public float totalTime = 240f;   // Total time in seconds (4 minutes)
    private float remainingTime;     // Time left
    private bool timerActive = true;

    void Start()
    {
        remainingTime = totalTime;   // Initialize the remaining time to the total time (4 minutes)
    }

    void Update()
    {
        if (timerActive)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;  // Decrease the time as game progresses
                DisplayTime(remainingTime);       // Display the updated remaining time
            }
            else
            {
                remainingTime = 0;
                StopTimer();
                PlayerDeath();  // Call death logic when time runs out
            }
        }
    }

    // Display the time in minutes and seconds (counting down)
    void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Change text color to red when there are 30 seconds left
        if (time <= 30f && time > 0f)
        {
            timerText.color = Color.red;
        }
  
    }

    public void StopTimer()
    {
        timerActive = false;  // Stop the timer
    }

    public float GetRemainingTime()
    {
        return remainingTime; // Return the remaining time
    }

    // Placeholder method for player death (replace with actual game logic)
    void PlayerDeath()
    {
        Debug.Log("Player is dead after time ran out!");
        // Add your actual death sequence here (e.g., restart level, show game over screen, etc.)
    }
}
