using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        transform.position = new Vector3(x, y, -10);
        
    }
}
