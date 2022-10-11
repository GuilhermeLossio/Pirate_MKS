using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAndActions : MonoBehaviour
{
    [SerializeField] private string shipClass;

    private GameObject player;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float speed = 3f;

    [SerializeField] public float distanceBetweenPlayer = 20f;

    [SerializeField] public float distaceToAttack = 5f;


    private Vector3 Destination;

    private Vector3 chasing;

    private Rigidbody2D shipRB;

    private bool isChasing = false;

    private bool isCooldawn = false;

    public bool isAlive = true;


   [SerializeField] private GameObject eventSys;


    
    
    void Start()
    {
        eventSys = GameObject.Find("EventSystem");
        shipRB = GetComponent<Rigidbody2D>();
        shipClass = gameObject.transform.parent.gameObject.name;
        string[] shipDivision = shipClass.Split("(Clone)");
        shipClass = shipDivision[0];
        //g(shipClass);

        player = GameObject.Find("Player");

        InvokeRepeating("RandMove" , 0f , 10f);
        
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < distaceToAttack)
        {
            LookAtThePlayer();
            if(shipClass == "ChaserShip")
            {
                Chase();
            }
            else if(shipClass == "ShooterShip")
            {
                Shot();
            }

        }
        else if(distance < distanceBetweenPlayer)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            LookAtThePlayer();
        }
        else
        {
            transform.position = Vector3.MoveTowards(this.transform.position, Destination , speed * Time.deltaTime);


            Vector3 relativePos = Destination - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, relativePos);
            transform.rotation = rotation;
        }
    }



    public void RandMove()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance > distanceBetweenPlayer)
        {
            float x = Random.Range(-230f, 260f);
            float y = Random.Range(-200f, 150f);
            Destination = this.transform.position + new Vector3(x, y, 0f);


            Vector2 direction = Destination - transform.position;

            direction.Normalize();
        }
    }

    private void Chase()
    {
        if(isChasing == false && isAlive)
        {
            chasing = transform.up * 3000f;
            shipRB.AddForce(chasing);
            isChasing = true;
            Invoke("StopForce", 0.5f);



            Invoke("StopChase", 3f);

        }
    }

    public void StopForce()
    {
        shipRB.velocity = new Vector2(0f, 0f);
        shipRB.angularVelocity = 0f;

    }

    public void StopChase()
    {
        isChasing = false;
    }

    private void Shot()
    {
        if(!isCooldawn && isAlive)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            isCooldawn = true;
            Invoke("SetCooldawn", 1f);
        }
    }


    private void LookAtThePlayer()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, relativePos);
        transform.rotation = rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && isChasing && !isCooldawn)
        {
            eventSys.SendMessage("TakeChaseDamage");
            Invoke("SetCooldawn", 1f);
            isCooldawn = true;
            
        }
    }

    private void SetCooldawn()
    {
        isCooldawn = false;
    }









}
