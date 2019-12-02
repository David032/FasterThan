using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entered the trigger");  
        //set trigger to change level or go to Highscore after level is complete.
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Player is within trigger");  
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object Exited the trigger");    
    }

}
