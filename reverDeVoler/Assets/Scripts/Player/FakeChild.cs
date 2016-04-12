using UnityEngine;
using System.Collections;

public class FakeChild : MonoBehaviour {

    public  Transform parentTransform; 

    private Quaternion basicRotation;
    private Vector3    offset;



    void Start () {
        offset        = transform.position - parentTransform.position;
        basicRotation = transform.rotation;
    }


    void LateUpdate () {
        transform.position = parentTransform.position + parentTransform.forward * offset.magnitude;
        transform.LookAt(parentTransform);
    }


}