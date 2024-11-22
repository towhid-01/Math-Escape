//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DoorRotation : MonoBehaviour
//{
//    public Transform player; // Reference to the player's transform
//    public float openDistance = 1.0f; // Distance at which the door opens
//    public float openAngle = 90.0f; // Angle to rotate the door to open
//    public float openSpeed = 2.0f; // Speed of door rotation
//    private bool isOpen = false; // Track if the door is open

//    private Quaternion closedRotation; // Store the initial rotation (closed state)
//    private Quaternion openRotation; // Store the target rotation (open state)

//    void Start()
//    {
//        // Save the door's original (closed) rotation
//        closedRotation = transform.rotation;

//        // Calculate the target open rotation (rotate by the open angle on Y-axis)
//        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
//    }

//    void Update()
//    {
//        // Calculate the distance between the player and the door
//        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

//        // If the player is within the openDistance and the door isn't open yet
//        if (distanceToPlayer <= openDistance && !isOpen)
//        {
//            // Rotate the door towards the open state
//            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);

//            // Check if the door is nearly open (close enough to the target rotation)
//            if (Quaternion.Angle(transform.rotation, openRotation) < 1.0f)
//            {
//                isOpen = true; // Mark the door as open
//            }
//        }
//        else if (distanceToPlayer > openDistance && isOpen)
//        {
//            // Rotate the door back to the closed state if the player moves away
//            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);

//            // Check if the door is nearly closed
//            if (Quaternion.Angle(transform.rotation, closedRotation) < 1.0f)
//            {
//                isOpen = false; // Mark the door as closed
//            }
//        }
//    }
//}
