using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject storyPanel;  

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void OpenStory()
    {
        storyPanel.SetActive(true);  
    }

    public void CloseStory()
    {
        storyPanel.SetActive(false); 
    }

   
    public void ExitGame()
    {
        Application.Quit();
    }
}
