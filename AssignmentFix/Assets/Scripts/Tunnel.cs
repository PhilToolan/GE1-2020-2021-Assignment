﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{

    public float curveRadius;
    public float tunnelRadius;
    //
    public int curveSegCount;
    public int tunnelSegCount;
    // mesh
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Tunnel";
        SetVertices();
        SetTriangles();
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

    void OnDrawGizmos ()
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

    void SetVertices()
    {
        vertices = new Vector3[tunnelSegCount * curveSegCount * 4];
        float uStep = (2f * Mathf.PI) / curveSegCount;
        CreateFirstQuadRing(uStep);
        mesh.vertices = vertices;
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
