using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSystem : MonoBehaviour
{

    public Tunnel tunnelPrefab;
    public int tunnelCount;

    private Tunnel[] tunnels;

    void Awake()
    {
        tunnels = new Tunnel[tunnelCount];
        for (int i = 0; i < tunnels.Length; i++)
        {
            Tunnel tunnel = tunnels[i] = Instantiate<Tunnel>(tunnelPrefab);
            tunnel.transform.SetParent(transform, false);
            tunnel.Generate();
            //Align tunnels
            if (i > 0)
            {
                tunnel.AlignWith(tunnels[i - 1]);
            }
        }
    }

    public Tunnel SetupFirstTunnel()
    {
        transform.localPosition = new Vector3(0f, -tunnels[0].CurveRadius);
        return tunnels[0];
    }

    public Tunnel SetupNextTunnel()
    {
        ShiftTunnels();
        AlignNextTunnelWithOrigin();
        tunnels[tunnels.Length - 1].Generate();
        tunnels[tunnels.Length - 1].AlignWith(tunnels[tunnels.Length - 2]);
        transform.localPosition = new Vector3(0f, -tunnels[0].CurveRadius);
        return tunnels[0];
    }

    void ShiftTunnels()
    {
        Tunnel temp = tunnels[0];
        for (int i = 1; i < tunnels.Length; i++)
        {
            tunnels[i - 1] = tunnels[i];
        }
        tunnels[tunnels.Length - 1] = temp;
    }

    void AlignNextTunnelWithOrigin()
    {
        Transform transformToAlign = tunnels[0].transform;
        for (int i = 1; i < tunnels.Length; i++)
        {
            tunnels[i].transform.SetParent(transformToAlign);
        }

        transformToAlign.localPosition = Vector3.zero;
        transformToAlign.localRotation = Quaternion.identity;

        for (int i = 1; i < tunnels.Length; i++)
        {
            tunnels[i].transform.SetParent(transform);
        }
    }
}
