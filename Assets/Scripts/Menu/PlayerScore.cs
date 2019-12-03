using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreTemplate;
    GameObject manager;
    GameController game;



    private void Awake()
    {
        scoreContainer = transform.Find("PlayerScore");
        scoreTemplate = scoreContainer.Find("PlayerScoreTemplate");

        manager = GameObject.FindGameObjectWithTag("GameController");
        game = manager.GetComponent<GameController>();


        CreateHighScore(scoreContainer);

    }

    private void CreateHighScore(Transform container)
    {
        Transform scoreTransform = Instantiate(scoreTemplate, container);
        scoreTransform.gameObject.SetActive(true);

        int score = (int)game.totalScore;
        scoreTransform.Find("PlayerScoreText").GetComponent<Text>().text = score.ToString();
    }
}
