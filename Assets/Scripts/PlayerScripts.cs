using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public GameObject bullet;

    [Header("Ship main status")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 10;

    [Header("Sprites")]
    public SpriteRenderer shipDead;
    public SpriteRenderer shipDestroyed;

    //Speed variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp = 0;

    public bool isChasing = false;

    private Vector2 chasing;


    Rigidbody2D shipRB;
    Collider2D carCollider;
    ShipHandler shipHandler;

    public GameObject enemyShip;



    void Awake()
    {
        shipRB = GetComponent<Rigidbody2D>();
        carCollider = GetComponentInChildren<Collider2D>();
        shipHandler = GetComponent<ShipHandler>();
    }

    void Start()
    {
        rotationAngle = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shot();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Chase();
        }
    }

    void FixedUpdate()
    {
        MotorForce();

        StopingRotation();

        ApplySteering();

    }

    void Shot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void MotorForce()
    {
        if (accelerationInput < 0)
        {
            accelerationInput = 0;
        }


        if (accelerationInput == 0)
        {
            shipRB.drag = Mathf.Lerp(shipRB.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            shipRB.drag = 0;
        }


        velocityVsUp = Vector2.Dot(transform.up, shipRB.velocity);



        if (velocityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
        {
            return;
        }

        //Limit so we cannot go faster in any direction while accelerating
        if (shipRB.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }   

        
        Vector2 motorForce = transform.up * accelerationInput * accelerationFactor;

        shipRB.AddForce(motorForce, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedToTurn = (shipRB.velocity.magnitude / 2);
        minSpeedToTurn = Mathf.Clamp01(minSpeedToTurn);

        rotationAngle -= steeringInput * turnFactor * minSpeedToTurn;

        shipRB.MoveRotation(rotationAngle);
    }

    void StopingRotation()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(shipRB.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(shipRB.velocity, transform.right);

        shipRB.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    float LateralSpeed()
    {
        return Vector2.Dot(transform.right, shipRB.velocity);
    }

    public bool IsTireScreeching(out float lateralVelocity, out bool isBraking)
    {
        lateralVelocity = LateralSpeed();
        isBraking = false;

        if (accelerationInput < 0 && velocityVsUp > 0)
        {
            isBraking = true;
            return true;
        }

        if (Mathf.Abs(LateralSpeed()) > 4.0f)
            return true;

        return false;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public float GetVelocityMagnitude()
    {
        return shipRB.velocity.magnitude;
    }



    public void Chase()
    {
        if(isChasing == false)
        {
            chasing = transform.up * 3000f;
            shipRB.AddForce(chasing);
            isChasing = true;
            Invoke("StopChase", 1f);
        }

    }

    public void StopChase()
    {
        //shipRB.AddForce(-chasing);
        isChasing = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(isChasing == true && other.gameObject.CompareTag("Enemy"))
        {
            enemyShip = other.gameObject.transform.parent.GetChild(1).gameObject;
            //Debug.Log(other.gameObject.transform.parent.GetChild(1));

            enemyShip.SendMessage("TakeAChase");


        }
        
    }

}
