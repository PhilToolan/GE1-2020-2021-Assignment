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
    private Transform world;
    private float worldRotation;

    void Start ()
    {
        world = tunnelSystem.transform.parent;
        currentTunnel = tunnelSystem.SetupFirstTunnel();
        SetUpCurrentTunnel();
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
            SetUpCurrentTunnel();
            systemRotation = delta * deltaToRotation;
        }

        tunnelSystem.transform.localRotation = Quaternion.Euler(0f, 0f, systemRotation);
    }

    void SetUpCurrentTunnel()
    {
        deltaToRotation = 360f / (2f * Mathf.PI * currentTunnel.CurveRadius);
        worldRotation += currentTunnel.RelativeRotation;
        if (worldRotation < 0f)
        {
            worldRotation += 360f;
        }
        else if (worldRotation >= 360f)
        {
            worldRotation -= 360f;
        }
        world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }
}
