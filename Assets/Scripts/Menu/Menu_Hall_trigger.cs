using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Hall_trigger : MonoBehaviour
{
    GameObject MainCam;
    public GameObject Hallway;

    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnTriggerEnter(Collider other)
    {
            Hallway.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
    }
}
