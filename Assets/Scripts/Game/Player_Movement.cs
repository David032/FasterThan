using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float playerAcceleration = 7;
    public float playerSneakSpeed = 3;
    public float playerWalkSpeed = 5;
    public float playerRunSpeed = 9;
    public float playerSprintDuration = 5;

    float playerSprintCharge;
    float playerMaxSpeed;
    Rigidbody playerBody;

    //death anim vars
    public bool canMove = true;
    bool rotate = true;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerMaxSpeed = playerWalkSpeed;
        playerSprintCharge = playerSprintDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();
        }
        else if (!canMove && rotate)
        {
            DeadCutScene();
        };
    }

    void Movement()
    {
        float mForward = Input.GetAxis("Vertical");
        float mSideways = Input.GetAxis("Horizontal");
        float mRotation = Input.GetAxis("Mouse X");

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitInfo;
        if (GetComponent<Collider>().Raycast(ray, out hitInfo, 100.0f))
        {
            string serface = hitInfo.transform.tag;
        }

        //sets max speed for different movement types
        if (Input.GetAxis("AltMovement") < -0.1f)
        {
            playerMaxSpeed = playerSneakSpeed;
            if (playerSprintDuration > playerSprintCharge)
            {
                playerSprintCharge += Time.deltaTime * 2.0f;
            }
        }
        else if (Input.GetAxis("AltMovement") > 0.1f && playerSprintCharge > 0)
        {
            playerMaxSpeed = playerRunSpeed;
            playerSprintCharge -= Time.deltaTime;
        }
        else
        {
            playerMaxSpeed = playerWalkSpeed;
            if (playerSprintDuration > playerSprintCharge)
            {
                playerSprintCharge += Time.deltaTime * 0.6f;
            }
        }


        if (mSideways < 0.0f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * playerMaxSpeed);
        }
        else if (Input.GetAxis("Horizontal") > 0.0f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerMaxSpeed);
        }
        if (mForward < 0.0f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * playerMaxSpeed);
        }
        else if (mForward > 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerMaxSpeed);
        }

        if (Input.GetAxis("Mouse X") != 0.0f)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, mRotation, 0f);
            playerBody.MoveRotation(playerBody.rotation * deltaRotation);
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

    public float playerSpeed() 
    {
        print(playerMaxSpeed);
        return playerMaxSpeed;
    }
}
