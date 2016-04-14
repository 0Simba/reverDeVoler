using UnityEngine;
using System.Collections;

public class EasyOndulation : MonoBehaviour {

    public float scale = 1;
    public float speed = 1;
    public Vector3 dir = Vector3.up;
    private Vector3 origin;

	// Use this for initialization
	void Start () {
        origin = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.time);
        transform.localPosition = origin + Mathf.Cos(Time.realtimeSinceStartup * speed) * scale * dir;	    
	}
}
