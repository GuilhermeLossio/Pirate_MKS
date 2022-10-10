using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameModeUIUpdate : MonoBehaviour
{
    public Status status;

    [SerializeField] private Text restantTime;

    [SerializeField] private Text score;


    [SerializeField] private int enemySpawnTime;



    [SerializeField] private int gameScore;



    // Start is called before the first frame update
    void Start()
    {
        status = SaveManager.Load();

        enemySpawnTime = status.gameTime;

        restantTime.text = enemySpawnTime.ToString();

        InvokeRepeating("UpdateScore", 1f, 1f);

        
    }

    // Update is called once per frame
    void UpdateScore()
    {
        enemySpawnTime--;
        restantTime.text = enemySpawnTime.ToString();
    }

    void updateScore()
    {
        gameScore++;
        score.text = gameScore.ToString();

    }
}
