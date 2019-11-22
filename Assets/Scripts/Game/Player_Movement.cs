using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerSpeed = 3;

    Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            playerBody.AddRelativeForce(Vector3.left * playerSpeed);
        }
        else if (Input.GetAxis("Horizontal") > 0.0f)
        {
            playerBody.AddRelativeForce(Vector3.right * playerSpeed);
        }

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            playerBody.AddRelativeForce(Vector3.back * playerSpeed);
        }
        else if (Input.GetAxis("Vertical") > 0.0f)
        {
            playerBody.AddRelativeForce(Vector3.forward * playerSpeed);
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            playerBody.AddTorque(Vector3.up * Input.GetAxis("Mouse X"));
        }
    }
}
