using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanMove : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
        {
            player.GetComponent<Player_Movement>().canMove = false;
            Debug.Log("Cant Move");
        }
    }
}
