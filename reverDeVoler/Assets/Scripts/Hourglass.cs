using UnityEngine;
using System.Collections;

public class Hourglass : Entity {

    void Start () {
        base.Init();

        PlaceOnFloor();
        RandomRotate();
    }


    void Update () {

    }


    void PlaceOnFloor () {
        Vector3 position   = transform.position;
        position.y         = 0;
        transform.position = position;        
    }


    void RandomRotate () {
        float xRotation = 0;
        float yRotation = Random.Range(-180, 180);
        float zRotation = Random.Range(-30, 30);

        transform.Rotate(xRotation, yRotation, zRotation);
    }
}