using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject spawn1, spawn2;

    void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        int spawn = (Random.Range(0, 2));

        if (spawn == 0)
        {
            transform.position = spawn1.transform.position;
        }
        else if (spawn == 1)
        {
            transform.position = spawn2.transform.position;
            transform.rotation = spawn2.transform.rotation;
        }
    }
}
