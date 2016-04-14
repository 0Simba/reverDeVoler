using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

    public float despawnTime;
    private float currentTime = 0;
    private Entity entityObject;

    void Start()
    {
        entityObject = GetComponent<Entity>();
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "ObstacleEnabler")
        {
            return;
        }
        entityObject.OwnDestroy();

    }

    void Update() {
        currentTime += Time.deltaTime; 
        if (currentTime > despawnTime) {
            entityObject.OwnDestroy();
        }
    }
}
