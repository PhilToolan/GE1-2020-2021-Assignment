using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{

    public float curveRadius;
    public float tunnelRadius;
    //
    public int curveSegCount;
    public int tunnelSegCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetPointOnTunnel (float u, float v)
    {
        Vector3 point;
        float r = (curveRadius + tunnelRadius + Mathf.Cos(v));
        point.x = r * Mathf.Sin(u);
        point.y = r * Mathf.Cos(u);
        point.z = tunnelRadius * Mathf.Sin(v);
        return point;
    }

    private void OnDrawGizmos ()
    {
        float uStep = (2f * Mathf.PI) / curveSegCount;
        float vStep = (2f * Mathf.PI) / tunnelSegCount;
        for (int u = 0; u < curveSegCount; u++)
        {
            for (int v = 0; v < tunnelSegCount; v++)
            {
                Vector3 point = GetPointOnTunnel(u * uStep, v * vStep);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }

    }
}
