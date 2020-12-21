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
        transform.localPosition = new Vector3(0f, -tunnels[0].CurveRadius);
        return tunnels[0];
    }

    void ShiftTunnels()
    {

    }

    void AlignNextTunnelWithOrigin()
    {

    }
}
