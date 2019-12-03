using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public CapsuleCollider player;
    public CapsuleCollider enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>();
        enemy = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //This is where the deadstate fires
            player.GetComponent<Player_Movement>().canMove = false;
            Debug.Log(player.GetComponent<Player_Movement>().canMove);
            print("Yo Dead!");
        }
    }
}
