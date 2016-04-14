﻿using UnityEngine;
using System.Collections;

public class CurveScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 p = vertices[i];
            float o = p.x / 5;
            Debug.Log(o);
            vertices[i].x = Mathf.Sin(o)*10;
            vertices[i].z = Mathf.Cos(o)*10;
        }
        mesh.vertices = (vertices);
        mesh.RecalculateNormals();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}