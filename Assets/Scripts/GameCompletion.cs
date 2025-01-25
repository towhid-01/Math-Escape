using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameCompletion : MonoBehaviour
{
    public Timer timer; 
    public TextMeshProUGUI completionMessage; 
    public float delayBeforeMenu = 3f; 

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
        
        timer.StopTimer();
        
        DisplayCompletionMessage();
        Invoke("ReturnToMainMenu", delayBeforeMenu);
    }

    void DisplayCompletionMessage()
    {
        float remainingTime = timer.GetRemainingTime();

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        completionMessage.text =$"You have Escaped the Dungeon!\nYour remaining time is {minutes} min {seconds} sec";

       
        completionMessage.gameObject.SetActive(true);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
