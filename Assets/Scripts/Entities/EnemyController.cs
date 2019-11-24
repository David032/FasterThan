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
    const float TrackingTime = 1f;
    const float HuntingTime = 1f;
    const float ResetTime = 1f;

    public State EnemyState = State.Patrolling;
    public NavMeshData levelMesh;

    [Range(1, 100)]
    public int FieldOfView = 45;
    [Range(1, 100)]
    public int viewDistance = 15;
    [Range(1, 10)]
    public float HuntingSpeed = 5;
    [Range(1, 100)]
    public float HearingRange = 30;

    public bool DebugView = false;

    public GameObject player;
    Vector3 targetPosition;
    NavMeshAgent agent;
    bool amActive = false;

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
            print("Didn't find player");
        }
        if (agent == null)
        {
            print("Didn't find agent");
        }
        DefineBoundries();
    }

    void DefineBoundries() 
    {
        MinX = (levelMesh.sourceBounds.center.x - levelMesh.sourceBounds.extents.x)/2;
        MaxX = (levelMesh.sourceBounds.center.x + levelMesh.sourceBounds.extents.x)/2;
        MinZ = (levelMesh.sourceBounds.center.z - levelMesh.sourceBounds.extents.z)/2;
        MaxZ = (levelMesh.sourceBounds.center.z + levelMesh.sourceBounds.extents.z)/2;
    }

    void Update()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetween < HearingRange && distanceBetween > viewDistance)
        {
            EnemyState = State.Tracking;
        }
        if (distanceBetween < viewDistance)
        {
            EnemyState = State.Hunting;
        }
        else
        {
            EnemyState = State.Patrolling;
        }

        if (!amActive)
        {
            amActive = true;
            switch (EnemyState)
            {               
                case State.Idle:
                    amActive = false;
                    break;
                case State.Patrolling:
                    print("DEBUG: IN PATROL STATE");
                    StartCoroutine(Patrol());
                    amActive = false;
                    break;
                case State.Tracking:
                    print("DEBUG: IN TRACKING STATE");
                    Vector3 target = locatePlayer();
                    StartCoroutine(Track(target));
                    amActive = false;
                    break;
                case State.Hunting:
                    print("DEBUG: IN HUNT STATE");
                    StartCoroutine(Hunt());
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
        rndNumber = Random.Range(offset * -1, offset);
        believedLocation.y += rndNumber;
        rndNumber = Random.Range(offset * -1, offset);
        believedLocation.z += rndNumber;

        Debug.DrawLine(transform.position, believedLocation,Color.blue);       
        return believedLocation;
    }


    IEnumerator Track(Vector3 theTarget) 
    {
        yield return new WaitForSeconds(TrackingTime);
        agent.SetDestination(theTarget);
        yield return new WaitForSeconds(ResetTime);
    }

    IEnumerator Patrol() 
    {
        Vector3 randomDestionation = new Vector3(Random.Range(MinX, MaxX) * 100, 1, Random.Range(MinZ, MaxZ) * 100);
        agent.SetDestination(randomDestionation);
        yield return new WaitForSeconds(ResetTime);
    }

    IEnumerator Hunt() 
    {
        agent.SetDestination(transform.position);
        RaycastHit hit;
        rayDirection = player.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) < FieldOfView)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, viewDistance))
            {
                GameObject viewedEntity = hit.collider.gameObject;
                if (viewedEntity != null)
                {
                    if (viewedEntity.tag == "Player")
                    {                        
                        float step = HuntingSpeed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, viewedEntity.transform.position, step);
                        transform.LookAt(viewedEntity.transform);
                    }
                }
            }
        }
        yield return new WaitForSeconds(ResetTime/10);
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
}

