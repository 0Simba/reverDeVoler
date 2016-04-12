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
        Destroy(gameObject);

    }

    void Update() {
        currentTime += Time.deltaTime; 
        if (currentTime > despawnTime) {
            entityObject.OwnDestroy();
        }
    }
}
