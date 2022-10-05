using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{
    PlayerScripts playerScripts;

    void Awake()
    {
        playerScripts = GetComponentInParent<PlayerScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
    }

    void UpdateSpeed()
    {
        float velocityMagnitude = playerScripts.GetVelocityMagnitude();

        float desiredEngineVolume = velocityMagnitude * 0.05f;

    }


}
