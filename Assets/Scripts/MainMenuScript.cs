using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Reference to the options menu and story panel
    public GameObject optionsMenu;
    public GameObject storyPanel;  // Reference to the story panel

    // Method for Play button
    public void PlayGame()
    {
        // Load the game scene (ensure your game scene is added in the Build Settings)
        SceneManager.LoadScene("Game");
    }

    // Method for Options button
    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
    }

    // Method to close options menu
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    // Method for Story button
    public void OpenStory()
    {
        storyPanel.SetActive(true);  // Show the story panel
    }

    // Method to close story panel and go back to main menu
    public void CloseStory()
    {
        storyPanel.SetActive(false);  // Hide the story panel
    }

    // Method for Exit button
    public void ExitGame()
    {
        Application.Quit();
    }
}
