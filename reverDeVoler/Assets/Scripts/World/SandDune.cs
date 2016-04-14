﻿using UnityEngine;
//using UnityEditor;
using System.Collections;

public class SandDune : MonoBehaviour {

    public Transform player;
    private Mesh mesh;

    // Use this for initialization
    void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        GenerateMesh();
        //AssetDatabase.CreateAsset(mesh, "Assets/test.asset");
        //AssetDatabase.SaveAssets();
        mesh.MarkDynamic();
	}

    void GenerateMesh()
    {
    transform.position = new Vector3(Mathf.Floor(player.position.x), 0, Mathf.Floor(player.position.z));
    Vector3[] vertices = mesh.vertices;
    for (int i = 0; i < vertices.Length; i++)
    {
        vertices[i].y = GetFloorLevel(transform.TransformPoint(vertices[i]));
    }
    mesh.vertices = (vertices);
    mesh.RecalculateNormals();
}
	
	// Update is called once per frame
	void Update () {
        GenerateMesh();
    }

    public float GetFloorLevel(Vector3 p)
    {
        return (Mathf.Sin(p.x * 0.5f + p.z * 0.1f) * (1 + Mathf.PerlinNoise(p.x*0.5f, p.z * 0.5f) * 1f) + Mathf.Sin(p.x*0.02f + p.z*0.5f) * 0.5f) * 0.5f;
    }
}
