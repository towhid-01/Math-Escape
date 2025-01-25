using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    public GameObject flameEffect;       
    public float deathDelay = 2f;        
    public GameObject deathUI;            
    public Animator animator;             
    public TextMeshProUGUI timerText;    
    public float gameTime = 240f;        

    private bool isPlayerDead = false;   

    private void Update()
    {
        if (isPlayerDead) return;  

        gameTime -= Time.deltaTime;

       
        if (gameTime <= 0f && !isPlayerDead)
        {
            isPlayerDead = true;
            DieByTime();  
        }
    }

    public void DieByFlame()
    {
        animator.SetTrigger("Die");
        StartCoroutine(DeathSequence());
    }

    public void DieByTime()
    {
        timerText.text = "Time's up!";
        timerText.color = Color.red;
        DieByFlame();  
    }

    private IEnumerator DeathSequence()
    {

        flameEffect.SetActive(true);

        yield return new WaitForSeconds(deathDelay);

        deathUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}
