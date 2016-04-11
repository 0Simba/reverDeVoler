using UnityEngine;
using System.Collections;

public class PlayerCollider : PlayerParent {

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Building") {
            Game.Over();
        }
        else {
            transform.position = player.startPoint.position + Vector3.up * 10;
        }
    }

}
