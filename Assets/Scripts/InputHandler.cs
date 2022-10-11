using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    PlayerScripts playerScripts;

    void Awake()
    {
        playerScripts = GetComponent<PlayerScripts>();
    }

    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        //Get input from Unity's input system.
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        playerScripts.SetInputVector(inputVector);

        

    }
}
