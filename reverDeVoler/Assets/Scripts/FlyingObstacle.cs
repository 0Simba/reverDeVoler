using UnityEngine;
using System.Collections;

public class FlyingObstacle : Entity {

    public float randomSpawnRotation = 0;


    void Start () {
        base.Init();

        RandomRotate();
        gameObject.tag = "Building";
    }



    void RandomRotate () {
        float xRotation = 0;
        float yRotation = Random.Range(-randomSpawnRotation, randomSpawnRotation);
        float zRotation = 0;

        transform.Rotate(xRotation, yRotation, zRotation);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObstacleEnabler")
        {
            GetComponent<Entity>().InstantOwnDestroy();
        }
    }
}