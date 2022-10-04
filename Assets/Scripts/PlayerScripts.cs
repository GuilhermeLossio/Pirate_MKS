using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    private float m_Speed;
    public Rigidbody2D m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Speed = 0.1f;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            //m_Rigidbody.velocity = transform.forward * m_Speed;
            m_Rigidbody.AddForce(transform.up * m_Speed, ForceMode2D.Impulse);
            Debug.Log(m_Rigidbody.velocity);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
            m_Rigidbody.rotation = m_Rigidbody.rotation + 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * m_Speed, Space.World);
            m_Rigidbody.rotation = m_Rigidbody.rotation - 1;
        }
    }
}
