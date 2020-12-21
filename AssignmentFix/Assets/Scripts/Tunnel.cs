using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{

    public float curveRadius;
    public float tunnelRadius;
    public float ringDistance;
    //
    public int curveSegCount;
    public int tunnelSegCount;
    // mesh
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    float curveAngle;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Tunnel";
        SetVertices();
        SetTriangles();
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GetPointOnTunnel (float u, float v)
    {
        Vector3 point;
        float r = (curveRadius + tunnelRadius + Mathf.Cos(v));
        point.x = r * Mathf.Sin(u);
        point.y = r * Mathf.Cos(u);
        point.z = tunnelRadius * Mathf.Sin(v);
        return point;
    }


    void SetVertices()
    {
        vertices = new Vector3[tunnelSegCount * curveSegCount * 4];
        //float uStep = (2f * Mathf.PI) / curveSegCount; // Closed tunnel
        float uStep = ringDistance / curveRadius; // Allow for partial/multi-curved tunnel 
        curveAngle = uStep * curveSegCount * (360f / (2f * Mathf.PI));
        CreateFirstQuadRing(uStep);
        int iDelta = tunnelSegCount * 4;
        for (int u = 2, i = iDelta; u <= curveSegCount; u++, i += iDelta)
        {
            CreateQuadRing(u * uStep, i);
        }
        mesh.vertices = vertices;
    }

    public void AlignWith (Tunnel tunnel)
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, -tunnel.curveAngle);
    }

    void CreateFirstQuadRing (float u)
    {
        float vStep = (2f * Mathf.PI) / tunnelSegCount;

        Vector3 vertexA = GetPointOnTunnel(0f, 0f);
        Vector3 vertexB = GetPointOnTunnel(u, 0f);
        for (int v = 1, i = 0; v <= tunnelSegCount; v++, i += 4)
        {
            vertices[i] = vertexA;
            vertices[i + 1] = vertexA = GetPointOnTunnel(0f, v * vStep);
            vertices[i + 2] = vertexB;
            vertices[i + 3] = vertexB = GetPointOnTunnel(u, v * vStep);
        }
    }

    void CreateQuadRing(float u, int i)
    {
        float vStep = (2f * Mathf.PI) / tunnelSegCount;
        int ringOffset = tunnelSegCount * 4;

        Vector3 vertex = GetPointOnTunnel(u, 0f);
        for (int v = 1; v <= tunnelSegCount; v++, i += 4)
        {
            vertices[i] = vertices[i - ringOffset + 2];
            vertices[i + 1] = vertices[i - ringOffset + 3];
            vertices[i + 2] = vertex;
            vertices[i + 3] = vertex = GetPointOnTunnel(u, v * vStep);
        }
    }

    void SetTriangles()
    {
        triangles = new int[tunnelSegCount * curveSegCount * 6];
        for (int t = 0, i = 0; t < triangles.Length; t += 6, i += 4)
        {
            triangles[t] = i;
            triangles[t + 1] = triangles[t + 4] = i + 1;
            triangles[t + 2] = triangles[t + 3] = i + 2;
            triangles[t + 5] = i + 3;
        }
        mesh.triangles = triangles;
    }
}
