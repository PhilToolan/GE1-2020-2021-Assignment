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
}
