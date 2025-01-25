using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;       
    public float totalTime = 240f;  
    private float remainingTime;    
    private bool timerActive = true;

    void Start()
    {
        remainingTime = totalTime;  
    }

    void Update()
    {
        if (timerActive)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;  
                DisplayTime(remainingTime);       
            }
            else
            {
                remainingTime = 0;
                StopTimer();
                PlayerDeath(); 
            }
        }
    }

    void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (time <= 30f && time > 0f)
        {
            timerText.color = Color.red;
        }
  
    }

    public void StopTimer()
    {
        timerActive = false;  
    }

    public float GetRemainingTime()
    {
        return remainingTime; 
    }

   
    void PlayerDeath()
    {
        Debug.Log("Player is dead after time ran out!");
       
    }
}
