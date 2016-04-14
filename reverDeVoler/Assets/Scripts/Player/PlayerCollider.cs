using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public LayerMask destroyableLayers;

    [Range(0, 100)]   public float destroyRadius;
    [Range(0.01f, 1)] public float chanceToDestroy;


    void OnTriggerEnter (Collider other) {
        if (other.tag == "Building") {
            Game.Over();
        }
        else {
            Player.instance.BonusPicked();
        }
    }
}
