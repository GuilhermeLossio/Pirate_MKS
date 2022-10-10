using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDetails : MonoBehaviour
{

    public int life = 10;

    public GameObject enemyShip;

    public GameObject fireParticles;


    public SpriteRenderer lifeImage;

    public Sprite deadShipImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        }

    }

}
