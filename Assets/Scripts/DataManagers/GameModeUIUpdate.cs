using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameModeUIUpdate : MonoBehaviour
{
    public Status status;

    [SerializeField] private Text restantTime;

    [SerializeField] private Text score;


    [SerializeField] private int gameTime;

    [SerializeField] private int lifeAmount = 100;




    [SerializeField] private int gameScore;

    [SerializeField] private GameObject player;


    //Enemys

    [SerializeField] private GameObject chaserEnemy;

    [SerializeField] private GameObject shooterEnemy;

    private Vector2 position;

    
    [SerializeField] private Slider playerLife;


    //End menu

    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private Text scoreValue;

    [SerializeField] private Text scoreOnScreen;
    

    

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(0,0);
        player = GameObject.Find("Player");

        status = SaveManager.Load();

        gameTime = status.gameTime;

        restantTime.text = gameTime.ToString();

        InvokeRepeating("UpdateGameTime", 1f, 1f);

        InvokeRepeating("SpawnEnemyByTime", 0f, status.spawnEnemyTime);

        InvokeRepeating("RegainLife", 10f,10f);
    }

    // Update is called once per frame
    void UpdateGameTime()
    {
        gameTime--;
        restantTime.text = gameTime.ToString();
        if(gameTime <= 0)
        {
            Die();
        }
    }

    public void UpdateScore()
    {
        gameScore++;
        score.text = gameScore.ToString();

    }

    private void SpawnEnemyByTime()
    {
        int randEnemy = Random.Range(1, 3);
        //Debug.Log(randEnemy);


        float x = Random.Range(-230f, 260f);
        float y = Random.Range(-250f, 150f);


        position = new Vector2(x, y);

        if(randEnemy == 1)
        {
            Instantiate(chaserEnemy, position, Quaternion.identity);
        }
        else if(randEnemy >= 2)
        {
            Instantiate(shooterEnemy, position, Quaternion.identity);
        }
    }

    public void TakeBulletDamage()
    {
        lifeAmount -= 20;
        if(lifeAmount <= 0)
        {
            Die();
        }
        playerLife.value = lifeAmount;


    }

    public void TakeChaseDamage()
    {
        Debug.Log("Recebi a mensagem");
        lifeAmount -= 40;
        if(lifeAmount <= 0)
        {
            Die();
        }
        playerLife.value = lifeAmount;


    }

    private void Die()
    {
        gameOverScreen.SetActive(true);
        scoreValue.text = scoreOnScreen.text;
        GetComponent<AudioSource>().Play(1);
        Time.timeScale = 0;
    }

    public void ReturnTimeScale()
    {
        Time.timeScale = 1;
    }

    private void RegainLife()
    {
        lifeAmount += 10;
        if(lifeAmount > 100)
        {
            lifeAmount = 100;
        }
        playerLife.value = lifeAmount;
    }


}
