﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Enemy")
        {
            other.gameObject.GetComponent<Player_Movement>().canMove = false;
            Debug.Log("Cant Move");
        }
    }
}
