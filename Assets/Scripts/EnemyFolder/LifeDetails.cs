using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDetails : MonoBehaviour
{

    [SerializeField] public int life = 10;

    public GameObject enemyShip;

    public GameObject fireParticles;

    private GameObject eventListner;


    public SpriteRenderer lifeImage;

    public Sprite damagedShipImage;

    public Sprite deadShipImage;

    void FixedUpdate()
    {
        transform.position = enemyShip.transform.position + new Vector3(0, 0.676f, 0);
    }

    public void ReciveBulletDamage()
    {
        if(life > 0)
        {
            life -= 5;
            lifeImage.size = new Vector2(life, 1);

            if(life <= 0)
            {
                //Destroy this ship
                enemyShip.GetComponent<SpriteRenderer>().sprite = deadShipImage;

                GetComponent<AudioSource>().Play(0);
                fireParticles.SetActive(true);

                eventListner = GameObject.Find("EventSystem");
                eventListner.SendMessage("UpdateScore");
                Invoke("DestroyMe", 4f);
                enemyShip.GetComponent<EnemyMovementAndActions>().isAlive = false;
            }
            else if(life <= 5)
            {
                enemyShip.GetComponent<SpriteRenderer>().sprite = damagedShipImage;
            }
        }

    }

    public void TakeAChase()
    {
        if(life > 0)
        {
            life = 0;
            lifeImage.size = new Vector2(life, 1);

            //Destroy this ship
            enemyShip.GetComponent<SpriteRenderer>().sprite = deadShipImage;

            GetComponent<AudioSource>().Play(0);
            fireParticles.SetActive(true);

            eventListner = GameObject.Find("EventSystem");
            eventListner.SendMessage("UpdateScore");
            Invoke("DestroyMe", 4f);
            enemyShip.GetComponent<EnemyMovementAndActions>().isAlive = false;


        }

    }


    private void DestroyMe()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

}
