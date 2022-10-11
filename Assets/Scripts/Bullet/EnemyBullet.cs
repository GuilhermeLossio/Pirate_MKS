using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]  private float bulletSpeed = 12f;
    private Rigidbody2D bulletRB;


    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        BulletMovementOnMap();
    }

    void BulletMovementOnMap()
    {
        bulletRB.velocity = transform.up * bulletSpeed;

        Debug.Log(transform.up);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            GameObject eventSys = GameObject.Find("EventSystem");

            eventSys.SendMessage("TakeBulletDamage");
            
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
