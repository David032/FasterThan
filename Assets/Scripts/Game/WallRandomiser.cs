using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandomiser : MonoBehaviour
{
    [Range(0, 2)]
    private int chances = 0;
    private float yPos = -8.0f;

    void Start()
    {
        RandomiserStandardWall();
    }

    void RandomiserStandardWall()
    {
        int doorNumber = 0;
        doorNumber = (Random.Range(0, (chances + 1)));

        DeleteDoor();
    }

    private void DeleteDoor()
    {

        
            transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
       
    }
}
