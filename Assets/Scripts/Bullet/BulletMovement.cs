using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float bulletSpeed = 20f;
    private Rigidbody2D bulletRB;

    [SerializeField] private GameObject restantLife;
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Enemy"))
        {
            restantLife = other.gameObject.transform.parent.GetChild(1).gameObject;

            restantLife.SendMessage("ReciveBulletDamage");
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Terrain"))
        {
            Debug.Log(other);
            Destroy(gameObject);
        }
    }
}
