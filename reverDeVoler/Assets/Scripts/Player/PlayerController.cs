using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1;
    Transform head;

	// Use this for initialization
	void Start () {
        head = transform.GetChild(0).GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += speed * head.forward * Time.deltaTime;
	}
}
