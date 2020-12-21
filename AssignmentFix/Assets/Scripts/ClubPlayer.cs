using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubPlayer : MonoBehaviour
{
    public TunnelSystem tunnelSystem;
    public float speed;

    private Tunnel currentTunnel;

    void Start ()
    {
        //currentTunnel = tunnelSystem.SetupFirstTunnel();
    }
}
