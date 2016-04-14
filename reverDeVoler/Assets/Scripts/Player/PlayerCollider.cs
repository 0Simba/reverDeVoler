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


    void DestroySomeBuildings () {
        Collider[] colliders = Physics.OverlapSphere(transform.position, destroyRadius, destroyableLayers);

        for (int i = 0; i < colliders.Length; ++i) {
            if (Random.Range(0f, 1f) <= chanceToDestroy) {
                Entity targetEntity = colliders[i].gameObject.GetComponent<Entity>();

                if (!targetEntity) {
                   //makes game laggy! Debug.LogError("[Game Week] PlayerCollider.DestroySomeBuildings -> Missing entity component");
                    continue;
                }

                targetEntity.OwnDestroy();
            }
        }
    }
}