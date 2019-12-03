using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string InputFootsteps;
    FMOD.Studio.EventInstance FootstepsEvent;
    FMOD.Studio.ParameterInstance WalkingParameter;
    public float walkingspeed;
    bool playerismoving;
    private float WalkingValue;
    private bool playerisgrounded;

    void Start()
    {
        FootstepsEvent = FMODUnity.RuntimeManager.CreateInstance(InputFootsteps);
        FootstepsEvent.getParameter("Footsteps Main", out WalkingParameter);


        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void Update()
    {
        WalkingParameter.setValue(WalkingValue);

        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            if (playerisgrounded == true)
            {
                playerismoving = true;
            }
            else if (playerisgrounded == false)
            {
                WalkingValue = 0.50f;
                playerismoving = false;
            }
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            playerismoving = false;
        }
    }

    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            FootstepsEvent.start();
        }
        else if (playerismoving == false)
        {
            //Debug.Log ("player is moving = false");
        }
    }

    void OnDisable()
    {
        playerismoving = false;
    }

    void OnTriggerStay(Collider FloorTag)
    {
        playerisgrounded = true;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hitInfo;
        if (GetComponent<Collider>().Raycast(ray, out hitInfo, 100.0f))
        {
            string serface = hitInfo.transform.tag;
        }

        if (hitInfo.transform.tag == ("Stone"))
        {
            WalkingValue = 1.50f;
        }
        if (hitInfo.transform.tag == ("Wood"))
        {
            WalkingValue = 2.50f;
        }
        if (hitInfo.transform.tag == ("Grass"))
        {
            WalkingValue = 3.50f;
        }
        if (hitInfo.transform.tag == ("Metal"))
        {
            WalkingValue = 4.50f;
        }

    }

    void OnTriggerExit(Collider FloorTag)
    {
        playerisgrounded = false;
    }
}
