﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerAcceleration = 7;
    public float playerSneakSpeed = 4;
    public float playerWalkSpeed = 6;
    public float playerRunSpeed = 10;

    float movementTypeTransitionSpeed = 1;
    float playerMaxSpeed;
    Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerMaxSpeed = playerWalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //sets max speed for different movement types
        if (Input.GetAxis("AltMovement") < -0.1f)
        {
            playerMaxSpeed = playerSneakSpeed;
        }
        else if (Input.GetAxis("AltMovement") > 0.1f)
        {
            playerMaxSpeed = playerRunSpeed;
        }
        else
        {
            playerMaxSpeed = playerWalkSpeed;
        }


        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            if (playerBody.velocity.magnitude < playerMaxSpeed)
            {
                playerBody.AddRelativeForce(Vector3.left * playerAcceleration);
            }
        }
        else if (Input.GetAxis("Horizontal") > 0.0f)
        {
            if (playerBody.velocity.magnitude < playerMaxSpeed)
            {
                playerBody.AddRelativeForce(Vector3.right * playerAcceleration);
            }
        }
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            if (playerBody.velocity.magnitude < playerMaxSpeed)
            {
                playerBody.AddRelativeForce(Vector3.back * playerAcceleration);
            }
        }
        else if (Input.GetAxis("Vertical") > 0.0f)
        {
            if (playerBody.velocity.magnitude < playerMaxSpeed)
            {
                playerBody.AddRelativeForce(Vector3.forward * playerAcceleration);
            }
        }

        if (Input.GetAxis("Mouse X") != 0.0f)
        {
            playerBody.AddTorque(Vector3.up * Input.GetAxis("Mouse X"));
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitInfo;
        if (GetComponent<Collider>().Raycast(ray, out hitInfo, 100.0f))
        {
            string serface = hitInfo.transform.tag;
        }

    }

    public float playerSpeed() 
    {
        return playerMaxSpeed;
    }
}
