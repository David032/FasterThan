using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSectionRandomiser : MonoBehaviour
{
    [Range(1, 3)]
    public int numberOfDoors;
    public GameObject Door1, Door2, Door3;
    private int chances = 5;
    private float yPos = -8.0f;

    void Start()
    {
        Debug.Log("Number of doors: " + numberOfDoors);
        RandomiserStandardDoors();
    }

    void RandomiserStandardDoors()
    {

        int doorNumber = 0;

        for (int i = 0; i <= 5; i++)
        {
            doorNumber = (Random.Range(0, (numberOfDoors + 1)));
            Debug.Log("Door Number: " + doorNumber);

            DeleteDoor(doorNumber);
        }
    }

    private void DeleteDoor(int doorNum)
    {
        if (doorNum == 1)
        {
            Door1.transform.localPosition = new Vector3(Door1.transform.localPosition.x, yPos, Door1.transform.localPosition.z);
        }
        else if (doorNum == 2)
        {
            Door2.transform.localPosition = new Vector3(Door2.transform.localPosition.x, yPos, Door2.transform.localPosition.z);
        }
        else if (doorNum == 3)
        {
            Door3.transform.localPosition = new Vector3(Door3.transform.localPosition.x, yPos, Door3.transform.localPosition.z);
        }
    }
}
