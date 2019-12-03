using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitGenerator : MonoBehaviour
{
    public GameObject ExitSpotA;
    public GameObject ExitSpotB;
    public GameObject WallSpotA;
    public GameObject WallSpotB;

    bool hasRan = false;

    private void Update()
    {
        if (!hasRan && SceneManager.GetActiveScene().buildIndex == 1)
        {
            ExitSpotA = GameObject.FindGameObjectWithTag("ExitSpotA");
            ExitSpotB = GameObject.FindGameObjectWithTag("ExitSpotB");
            WallSpotA = GameObject.FindGameObjectWithTag("WallSpotA");
            WallSpotB = GameObject.FindGameObjectWithTag("WallSpotB");

            int rndNumber = Random.Range(0, 2);
            if (rndNumber == 0)
            {
                ExitSpotA.SetActive(true);
                WallSpotA.SetActive(false);
                ExitSpotB.SetActive(false);
                WallSpotB.SetActive(true);
            }
            else
            {
                ExitSpotA.SetActive(false);
                WallSpotA.SetActive(true);
                ExitSpotB.SetActive(true);
                WallSpotB.SetActive(false);
            }
            hasRan = true;
        }
    }
}
