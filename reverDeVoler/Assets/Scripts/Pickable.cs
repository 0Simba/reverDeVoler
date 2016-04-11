using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

    void OnTriggerEnter (Collider other) {
        Destroy(gameObject);

    }
}
