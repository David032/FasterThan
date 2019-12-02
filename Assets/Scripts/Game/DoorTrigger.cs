using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entered the trigger");  
        //set trigger to change level or go to Highscore after level is complete.
        //can add anim here for player
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Player is within trigger");  
        //added this incase wqe needed a certain amount of time at the door e.g (takes 5 seconds to open)
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited the trigger");    
        //debug check for error checks. if player leaves trigger.
    }

}
