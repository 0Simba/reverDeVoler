﻿using UnityEngine;
using System.Collections;

public class CurveScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        float delta = Mathf.Cos(-1) * 10;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 p = vertices[i];
            float o = p.x / 5;
            float d = p.z / 5;
            vertices[i].x = Mathf.Sin(o)*10;
            vertices[i].z = Mathf.Sin(d) * 10;
            vertices[i].y = -Mathf.Cos(o) * 10 + delta;
        }
        
        mesh.vertices = (vertices);
        mesh.RecalculateNormals();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
