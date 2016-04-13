using UnityEngine;
using System.Collections;

public class SandDune : MonoBehaviour {

    public Transform player;
    private Mesh mesh;

    // Use this for initialization
    void Start() {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.MarkDynamic();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Floor(player.position.x), 0, Mathf.Floor(player.position.z));
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            var p = transform.TransformPoint(vertices[i]);
            vertices[i].y = Mathf.Sin(p.x * 0.5f + p.z * 0.1f) * (1 + Mathf.PerlinNoise(p.x, p.z)) * 0.5f;
        }
        mesh.vertices = (vertices);
        mesh.RecalculateNormals();
    }
}
