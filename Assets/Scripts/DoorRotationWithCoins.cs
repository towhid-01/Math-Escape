using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DoorRotationWithCoins : MonoBehaviour
{
    public Transform player;    
    public float openDistance = 1.0f; 
    public float openAngle = 90.0f; 
    public float openSpeed = 2.0f; 
    public int requiredCoins = 5; 
    public TMP_Text promptText; 

    private bool isOpen = false; 
    private PlayerCoins playerCoins; 

    private Quaternion closedRotation; 
    private Quaternion openRotation; 

    void Start()
    {
       
        closedRotation = transform.rotation;

        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);

        promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        
        if (playerCoins == null) return;

       
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

       
        if (distanceToPlayer <= openDistance && !isOpen)
        {
           
            if (playerCoins.currentCoins >= requiredCoins)
            {
               
                transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);

                
                if (Quaternion.Angle(transform.rotation, openRotation) < 1.0f)
                {
                    isOpen = true; 
                    promptText.gameObject.SetActive(false); 
                }
            }
            else
            {
              
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
            playerCoins = other.GetComponent<PlayerCoins>(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.gameObject.SetActive(false);
        }
    }
}
  