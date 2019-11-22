using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    const float TrackingTime = 5f;
    const float HuntingTime = 5f;
    const float ResetTime = 5f;


    GameObject player;

    Vector3 targetPosition;
    NavMeshAgent agent;
    bool amTracking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            print("Didn't find player");
        }
        if (agent == null)
        {
            print("Didn't find agent");
        }
    }

    void Update()
    {
        if (!amTracking)
        {
            amTracking = true;
            StartCoroutine(Track());
            print("Current target:" + targetPosition);
        }
    }

    IEnumerator Track() 
    {
        //This should be the 'patrol around' function
        targetPosition = transform.position;
        yield return new WaitForSeconds(TrackingTime);
        StartCoroutine(Hunt());
        print("Am hunting");
    }

    IEnumerator Hunt() 
    {
        //This should be fired whenever the player makes a sound above a certain volume.
        targetPosition = player.transform.position;
        yield return new WaitForSeconds(HuntingTime);
        print("Am moving towards " +targetPosition);
        agent.SetDestination(targetPosition);
        yield return new WaitForSeconds(ResetTime);
        amTracking = false;
    }
}
