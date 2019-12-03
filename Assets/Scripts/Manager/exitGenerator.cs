using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitGenerator : MonoBehaviour
{
    public GameObject ExitSpotA;
    public GameObject ExitSpotB;

    bool hasRan = false;

    private void Update()
    {
        if (!hasRan && SceneManager.GetActiveScene().buildIndex == 1)
        {
            print("Beep");
            ExitSpotA = GameObject.FindGameObjectWithTag("ExitSpotA");
            ExitSpotB = GameObject.FindGameObjectWithTag("ExitSpotB");

            int rndNumber = Random.Range(0, 2);
            print(rndNumber);
            if (rndNumber == 0)
            {
                ExitSpotA.SetActive(true);
                ExitSpotB.SetActive(false);
            }
            else
            {
                ExitSpotA.SetActive(false);
                ExitSpotB.SetActive(true);
            }
            hasRan = true;
        }
    }
}
