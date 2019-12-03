using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitGenerator : MonoBehaviour
{
    public GameObject[] ExitSpotA;
    public GameObject[] ExitSpotB;

    bool hasRan = false;

    private void Update()
    {
        if (!hasRan && SceneManager.GetActiveScene().buildIndex == 1)
        {
            ExitSpotA = GameObject.FindGameObjectsWithTag("ExitSpotA");
            ExitSpotB = GameObject.FindGameObjectsWithTag("ExitSpotB");

            int rndNumber = Random.Range(0, 2);
            if (rndNumber == 0)
            {
                ExitSpotA[0].SetActive(true);
                ExitSpotA[1].SetActive(true);
                ExitSpotB[0].SetActive(false);
                ExitSpotB[1].SetActive(false);
            }
            else
            {
                ExitSpotA[0].SetActive(false);
                ExitSpotA[1].SetActive(false);
                ExitSpotB[0].SetActive(true);
                ExitSpotB[1].SetActive(true);
            }
            hasRan = true;
        }
    }
}
