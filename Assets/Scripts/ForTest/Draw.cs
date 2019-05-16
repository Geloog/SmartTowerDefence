﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    Mesh mesh;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        count = (count + 1) % 361;

        mesh.Clear();

        Vector3[] vertices = new Vector3[360 + 1];
        int[] triangles = new int[360 * 3];
        vertices[360] = new Vector3(0, 0, 0);

        for (int i = 0; i < count; i++)
        {
            vertices[i] = new Vector3(Mathf.Sin(i * Mathf.Deg2Rad), Mathf.Cos(i * Mathf.Deg2Rad), 0);
            triangles[i * 3] = 360;
            triangles[i * 3 + 1] = i;
            triangles[i * 3 + 2] = (i + 1) % 360;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        Debug.Log(mesh.vertexCount);
    }
}