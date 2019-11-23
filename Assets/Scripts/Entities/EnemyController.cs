using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Patrolling,
    Tracking,
    Hunting
}

public class EnemyController : MonoBehaviour
{
    const float TrackingTime = 5f;
    const float HuntingTime = 5f;
    const float ResetTime = 5f;

    public State EnemyState = State.Idle;

    public GameObject player;

    public Vector3 targetPosition;
    NavMeshAgent agent;
    public bool amActive = false;

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
        if (!amActive)
        {
            amActive = true;
            switch (EnemyState)
            {               
                case State.Idle:
                    amActive = false;
                    break;
                case State.Patrolling:
                    amActive = false;
                    break;
                case State.Tracking:
                    Vector3 target = locatePlayer();
                    Track(target);
                    amActive = false;
                    break;
                case State.Hunting:
                    amActive = false;
                    break;
                default:
                    break;
            }
        }

    }

    Vector3 locatePlayer() 
    {
        Vector3 believedLocation = player.transform.position;
        Player_Movement playerMovement = player.GetComponent<Player_Movement>();
        //print("Player located");
        int pSpeed = Mathf.RoundToInt(playerMovement.playerSpeed());
        int offset = 4;

        if (pSpeed == playerMovement.playerSneakSpeed)
        {
            offset = 10;
        }
        else if (pSpeed == playerMovement.playerWalkSpeed)
        {
            offset = 5;
        }
        else if (pSpeed == playerMovement.playerRunSpeed)
        {
            offset = 1;
        }

        int rndNumber = Random.Range(offset * -1, offset);
        believedLocation.x += rndNumber;
        //print("X modified by: " + rndNumber);
        rndNumber = Random.Range(offset * -1, offset);
        believedLocation.y += rndNumber;
        //print("Y modified by: " + rndNumber);
        rndNumber = Random.Range(offset * -1, offset);
        believedLocation.z += rndNumber;
        //print("Z modified by: " + rndNumber);

        //Debug.DrawLine(transform.position, believedLocation,Color.red);
        
        //print("Located at: " + Time.time);
        return believedLocation;
    }


    IEnumerator Track(Vector3 theTarget) 
    {
        print(theTarget);
        yield return new WaitForSeconds(0.1f);
        agent.SetDestination(theTarget);
        print("Moving to target");
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator Hunt() 
    {
        //This should be fired whenever the player makes a sound above a certain volume.
        targetPosition = player.transform.position;
        yield return new WaitForSeconds(HuntingTime);
        print("Am moving towards " +targetPosition);
        agent.SetDestination(targetPosition);
        yield return new WaitForSeconds(ResetTime);
        amActive = false;
    }
}
