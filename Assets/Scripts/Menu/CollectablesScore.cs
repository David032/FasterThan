using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesScore : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    GameObject manager;
    GameController game;


    private void Awake()
    {
        scoreContainer = transform.Find("GameCollectables");
        scoreTemplate = scoreContainer.Find("GameCollectablesTemplate");

        manager = GameObject.FindGameObjectWithTag("GameController");
        game = manager.GetComponent<GameController>();


        CreatePlayerCollectableAmount(scoreContainer);
        CreateGameCollectableAmount(scoreContainer);

    }

    private void CreatePlayerCollectableAmount(Transform container)
    {
        Transform scoreTransform = Instantiate(scoreTemplate, container);
        scoreTransform.gameObject.SetActive(true);

        int score = (int)game.collectableCount;
        scoreTransform.Find("PlayerCollectedText").GetComponent<Text>().text = score.ToString();
    }

    private void CreateGameCollectableAmount(Transform container)
    {
        Transform scoreTransform = Instantiate(scoreTemplate, container);
        scoreTransform.gameObject.SetActive(true);

        int score = game.collectableAmount.Length;
        scoreTransform.Find("AmountToCollectText").GetComponent<Text>().text = score.ToString();
    }
}
