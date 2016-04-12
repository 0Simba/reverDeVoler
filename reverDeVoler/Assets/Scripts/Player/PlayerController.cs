using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float minSpeed = 1;
    public float maxSpeed = 100;
    public float gravityAcc = 1;
    public float rollSpeed = 1;
    public float rollTranslate = 1;
    private float speed = 0;
    Transform head;

	// Use this for initialization
	void Start () {
        head = transform.GetChild(0).GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 move = Vector3.zero;
        float headingZ = head.forward.y;
        speed += gravityAcc * -headingZ * Time.deltaTime;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        move += speed * head.forward * Time.deltaTime;
        float rot = head.rotation.eulerAngles.z;
        
        if (rot > 180)
        {
            rot = 360 - rot;
        } else
        {
            rot = -rot;
        }
        transform.Rotate(0, rollSpeed * rot * Time.deltaTime, 0);
        Vector3 right = (new Vector3(head.right.x, 0, head.right.z)).normalized;
        move += rollTranslate * rot * right;
        transform.position += move;
    }
}
