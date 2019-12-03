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

        if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
        {

                playerismoving = true;
            
        }
        else
        {
            playerismoving = false;
        }

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

    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            FootstepsEvent.start();
        }
    }

    void OnDisable()
    {
        playerismoving = false;
    }



}
