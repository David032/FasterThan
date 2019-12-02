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
        //do we need to add a state for Capture of player?
}

public class EnemyController : MonoBehaviour
{
    const float TrackingTime = 1f;
    const float HuntingTime = 1f;
    const float ResetTime = 3.5f;

    public State EnemyState = State.Patrolling;
    public NavMeshData levelMesh;

    [Range(1, 100)]
    public int FieldOfView = 45;
    [Range(1, 100)]
    public int viewDistance = 15;
    [Range(1, 10)]
    public float HuntingSpeed = 5;
    [Range(1, 10)]
    public float BaseSpeed = 5;
    [Range(1, 100)]
    public float HearingRange = 30;

    public bool DebugView = false;

    public GameObject player;
    Vector3 targetPosition;
    NavMeshAgent agent;
    bool amTracking = false;
    bool amHunting = false;
    bool amPatrolling = false;

    float MinX;
    float MaxX;
    float MinZ;
    float MaxZ;

    Vector3 rayDirection;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            print("Didn't find player!");
        }
        if (agent == null)
        {
            print("Didn't find agent!");
        }
        DefineBoundries();
    }

    void DefineBoundries() 
    {
        MinX = levelMesh.sourceBounds.min.x * 0.6f;
        MaxX = levelMesh.sourceBounds.max.x * 0.6f;
        MinZ = levelMesh.sourceBounds.min.z * 0.6f;
        MaxZ = levelMesh.sourceBounds.max.z * 0.6f;
    }

    void Update()
    {
        //distanceBetween is broken currently geting direct distance rather than via navmesh
        float distanceBetween = GetPathLength(agent.path);

        if (distanceBetween < HearingRange && distanceBetween > viewDistance)
        {
            EnemyState = State.Tracking;
        }
        else if (distanceBetween < viewDistance)
        {
            EnemyState = State.Hunting;
        }
        else
        {
            EnemyState = State.Patrolling;
        }

        switch (EnemyState)
        {
            case State.Idle:
                break;
            case State.Patrolling:
                if (!amPatrolling)
                {
                    print("DEBUG: IN PATROL STATE");
                    StartCoroutine(Patrol());
                }
                break;
            case State.Tracking:
                if (!amTracking)
                {
                    print("DEBUG: IN TRACKING STATE");
                    StartCoroutine(Track());
                }
                break;
            case State.Hunting:
                if (!amHunting)
                {
                    print("DEBUG: IN HUNT STATE");
                    StartCoroutine(Hunt());
                }
                break;
            default:
                break;
        }

    }

    Vector3 locatePlayer() 
    {
        Vector3 believedLocation = player.transform.position;
        Player_Movement playerMovement = player.GetComponent<Player_Movement>();
        int pSpeed = Mathf.RoundToInt(playerMovement.playerSpeed());
        int offset = Mathf.RoundToInt(playerMovement.playerRunSpeed) + Mathf.RoundToInt(playerMovement.playerSneakSpeed) - pSpeed;

        int rndNumber = Random.Range(offset * -1, offset);
        believedLocation.x += rndNumber;
        rndNumber = Random.Range(offset * -1, offset);
        believedLocation.y += rndNumber;
        rndNumber = Random.Range(offset * -1, offset);
        believedLocation.z += rndNumber;

        Debug.DrawLine(transform.position, believedLocation,Color.blue);       
        return believedLocation;
    }


    IEnumerator Track() 
    {
        amTracking = true;
        Vector3 theTarget = locatePlayer();
        agent.SetDestination(theTarget);
        yield return new WaitForSeconds(ResetTime/3);
        amTracking = false;
    }

    IEnumerator Patrol() 
    {
        amPatrolling = true;
        Vector3 randomDestionation = new Vector3(Random.Range(MinX, MaxX), 1, Random.Range(MinZ, MaxZ));

        agent.SetDestination(randomDestionation);
        yield return new WaitForSeconds(ResetTime);
        amPatrolling = false;
    }

    IEnumerator Hunt() 
    {
        amHunting = true;
        agent.SetDestination(player.transform.position);
        agent.speed = HuntingSpeed;
        yield return new WaitForSeconds(ResetTime/10);
        amHunting = false;
        agent.speed = BaseSpeed;
    }

    void OnDrawGizmos()
    {
        if (DebugView)
        {
            if (player.transform == null)
            {
                return;
            }
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
            Vector3 frontRayPoint = transform.position + (transform.forward * viewDistance);
            //Approximate perspective visualization
            Vector3 leftRayPoint = frontRayPoint;
            leftRayPoint.x += FieldOfView;// * 0.5f;
            Vector3 rightRayPoint = frontRayPoint;
            rightRayPoint.x -= FieldOfView;// * 0.5f;
            Debug.DrawLine(transform.position, frontRayPoint, Color.green);
            Debug.DrawLine(transform.position, leftRayPoint, Color.green);
            Debug.DrawLine(transform.position, rightRayPoint, Color.green);
        }
    }


    //gets distance to player via the navmesh
    float GetPathLength(NavMeshPath path)
    {
        path.ClearCorners();
        float lng = 0.0f;

        NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path); ///changed to Navmesh.Areas from Zero.

        if ((path.status != NavMeshPathStatus.PathInvalid) && (path.corners.Length > 1))
        {
            for (int i = 1; i < path.corners.Length; ++i)
            {
                lng += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
        }
        else
        {
            lng = Vector3.Distance(transform.position, player.transform.position);
        }

        return lng;
    }
}

