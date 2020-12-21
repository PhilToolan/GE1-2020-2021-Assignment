using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubPlayer : MonoBehaviour
{
    public TunnelSystem tunnelSystem;
    public float speed;

    private Tunnel currentTunnel;
    private float distanceTraveled;
    private float deltaToRotation;
    private float systemRotation;

    void Start ()
    {
        currentTunnel = tunnelSystem.SetupFirstTunnel();
    }

    void Update()
    {
        float delta = speed * Time.deltaTime;
        distanceTraveled += delta;
        systemRotation += delta * deltaToRotation;

        if (systemRotation >= currentTunnel.CurveAngle)
        {
            delta = (systemRotation - currentTunnel.CurveAngle) / deltaToRotation;
            currentTunnel = tunnelSystem.SetupNextTunnel();
            deltaToRotation = 360f / (2f * Mathf.PI * currentTunnel.CurveRadius);
            systemRotation = delta * deltaToRotation;
        }

        tunnelSystem.transform.localRotation = Quaternion.Euler(0f, 0f, systemRotation);
    }
}
