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
            //Allign tunnels
            if (i > 0)
            {
                tunnel.AlignWith(tunnels[i - 1]);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
