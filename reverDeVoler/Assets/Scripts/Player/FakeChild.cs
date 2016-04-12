using UnityEngine;
using System.Collections;

public class FakeChild : MonoBehaviour {

    public  Transform parentTransform; 

    private Quaternion basicRotation;
    private Vector3    offset;



    void Start () {
        float aspectRatio = parentTransform.GetChild(0).GetChild(0).GetComponent<Camera>().aspect;
        transform.localScale = new Vector3(aspectRatio, 1, 1);
    }


    void LateUpdate () {
        transform.position = parentTransform.position;
        transform.rotation = parentTransform.rotation;

    }


}