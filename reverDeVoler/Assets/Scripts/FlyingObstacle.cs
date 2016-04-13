using UnityEngine;
using System.Collections;

public class FlyingObstacle : Entity {


    void Start () {
        base.Init();

        RandomRotate();
        gameObject.tag = "Building";
    }



    void RandomRotate () {
        float xRotation = 0;
        float yRotation = Random.Range(-180, 180);
        float zRotation = 0;

        transform.Rotate(xRotation, yRotation, zRotation);
    }
}