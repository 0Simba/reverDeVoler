using UnityEngine;
using System.Collections;

public class SandDune : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            var p = transform.TransformPoint(vertices[i]);

            vertices[i].z = Mathf.Sin(p.x*0.5f + p.z * 0.1f) * (1 + Mathf.PerlinNoise(p.x, p.z)) * 0.5f;
            Debug.Log(vertices[i].y);
        }
        mesh.vertices = (vertices);
        mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
