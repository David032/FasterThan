using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameObject manager;
    float current_game_time;


    //Uncomment lines 15 and 22 when ScoreSystem Branch is finally merged!!
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController");
        //current_game_time = manager.GetComponent<GameController>().GameTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Destroy(gameObject);
            //manager.GetComponent<GameController>().GameTime = game_time + 15.0f;
        }
    }
}
