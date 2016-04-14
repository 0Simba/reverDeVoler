using UnityEngine;
using System.Collections;

public class FakeChild : MonoBehaviour {

    public  Transform parentTransform; 

    private Quaternion basicRotation;
    private Vector3    offset;






    void LateUpdate () {
        transform.position = parentTransform.position;
        transform.rotation = parentTransform.rotation;
    }


}