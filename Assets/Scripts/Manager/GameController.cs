using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float GameTime; //time the game lasts for
    public float totalScore;
    public float collectableCount = 0;
    public GameObject[] collectableAmount;
    float timeScore;
    

    bool generating;

    string playerName;

    bool muted;
    void Start()
    {
        collectableAmount = GameObject.FindGameObjectsWithTag("Collectable");

        //REMINDER!! Remove Debug once game is passed debug stage
        if(collectableAmount.Length == 0)
        {
            Debug.Log("No game objects found with tag Collectable");
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !generating)
        {
            StartCoroutine(GameTimer());
            generating = true;
            playerName = "";
        }
        else if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            generating = false;
        }



        totalScore = GameTime;
        Debug.Log(totalScore); //Delete at a later date!

    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(GameTime);
        SceneManager.LoadScene(3);
    }

    public bool IsMuted()
    {
        return muted;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Collectable")
        {
            collectableCount++;
        }
    }
}
