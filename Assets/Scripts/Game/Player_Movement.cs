using System.Collections;
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
    public bool canMove = true;
    bool rotate = true;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerMaxSpeed = playerWalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Movement();
        }
        else if(!canMove && rotate)
        {
            DeadCutScene();
        };
        

    }

    void Movement()
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

    void DeadCutScene()
    {
        Vector3 currentRotation = playerBody.rotation.eulerAngles;
        Quaternion rot = Quaternion.LookRotation(enemy.transform.position - playerBody.transform.position);
        playerBody.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 8);
        //rotate = true;
        //if (rotate == true)
        //{
        //    playerBody.transform.rotation = Quaternion.Slerp(playerBody.transform.rotation, newRot, 0.2f);
        //    Debug.Log("rotating");
        //}

        //if (currentRotation.y == newRot.y)
        //{
        //    rotate = false;
        //    Debug.Log("Stop");
        //}


    }
}
