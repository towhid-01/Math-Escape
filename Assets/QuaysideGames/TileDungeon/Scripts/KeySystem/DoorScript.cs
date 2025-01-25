using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator anim;
    public GameObject door; // Reference to the door GameObject
    public string animTrigger; // Trigger name to open the door
    private bool isOpen = false; // To track if the door is already opened

    // Start is called before the first frame update
    void Start()
    {
        anim = door.GetComponent<Animator>(); // Get the Animator component from the door
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag and if the door isn't open yet
        if (other.CompareTag("Player") && !isOpen)
        {
            anim.SetTrigger(animTrigger); // Trigger the door opening animation
            Debug.Log("Door is opening"); // Log to confirm the door is opening
            isOpen = true; // Mark the door as opened
        }
    }

    // Optional: Close the door when the player leaves the trigger area
    private void OnTriggerExit(Collider other)
    {
        // If you want the door to close when the player leaves the area
        if (other.CompareTag("Player") && isOpen)
        {
            anim.SetTrigger("CloseDoor"); // Trigger the door closing animation
            Debug.Log("Door is closing");
            isOpen = false; // Mark the door as closed
        }
    }
}
