using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubPlayer : MonoBehaviour
{
    public TunnelSystem tunnelSystem;
    public float speed;
    public Transform target1;
    public Transform target2;
    public bool viz1 = true;
    public float rotSpeed;

    private Tunnel currentTunnel;
    private float distanceTraveled;
    private float deltaToRotation;
    private float systemRotation;
    private Transform world;
    private float worldRotation;
    private Vector3 cameraPosition;

    void Start ()
    {
        world = tunnelSystem.transform.parent;
        currentTunnel = tunnelSystem.SetupFirstTunnel();
        cameraPosition = this.transform.position;
        SetUpCurrentTunnel();
        LookAtVisual();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LookAtVisual();
        }
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

    void LookAtVisual()
    {
        if (viz1 == true)
        {
            viz1 = false;
            Vector3 toTarget = target1.transform.position - transform.position;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toTarget), rotSpeed * Time.deltaTime);
            speed = 0;
        }

        if (viz1 == false)
        {
            viz1 = true;
            Vector3 toTarget = target2.transform.position - transform.position;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toTarget), rotSpeed * Time.deltaTime);
            speed = 5;
        }
    }
}
