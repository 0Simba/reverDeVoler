using UnityEngine;
using System.Collections;

public class PlayerHitBuilding : MonoBehaviour {

    public Vector3 startPosition;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Building") {
            transform.position = startPosition;
        }
        else {
            transform.position = transform.position + Vector3.up * 10;
        }
    }
}
