using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithPlayer : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        transform.position = new Vector3(x, y, -10);
        
    }
}
