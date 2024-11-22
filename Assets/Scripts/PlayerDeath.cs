using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    public GameObject flameEffect;       // Flame effect on player when they die
    public float deathDelay = 2f;        // Delay before showing death message
    public GameObject deathUI;            // "You're Dead" UI panel
    public Animator animator;             // Animator for triggering death animation
    public TextMeshProUGUI timerText;     // Timer UI text
    public float gameTime = 240f;         // Total game time in seconds (5 minutes)

    private bool isPlayerDead = false;    // Track if the player is dead

    private void Update()
    {
        if (isPlayerDead) return;  // Stop updates if the player is dead

        // Decrease game time
        gameTime -= Time.deltaTime;

        // Check if time runs out
        if (gameTime <= 0f && !isPlayerDead)
        {
            isPlayerDead = true;
            DieByTime();  // Trigger player death due to time expiration
        }
    }

    // Function to handle death due to flame (triggered by external events)
    public void DieByFlame()
    {
        animator.SetTrigger("Die");
        StartCoroutine(DeathSequence());
    }

    // Function to handle death due to time expiration
    public void DieByTime()
    {
        timerText.text = "Time's up!";
        timerText.color = Color.red;
        DieByFlame();  // Use the same death sequence for time expiration
    }

    // Coroutine to handle death sequence (flame effect, delay, UI display, then scene change)
    private IEnumerator DeathSequence()
    {
        // Activate flame effect on player
        flameEffect.SetActive(true);

        // Wait for the flame effect duration
        yield return new WaitForSeconds(deathDelay);

        // Display the death UI
        deathUI.SetActive(true);

        // Wait for a short period before returning to the main menu
        yield return new WaitForSeconds(2f);

        // Load the main menu scene (index 0)
        SceneManager.LoadScene(0);
    }
}
