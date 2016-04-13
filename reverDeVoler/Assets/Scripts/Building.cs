using UnityEngine;
using System.Collections;

public class Building : Entity {

    public float zRotationMax = 30;


    void Start () {
        base.Init();

        PlaceOnFloor();
        RandomRotate();

        gameObject.tag = "Building"; 
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
        float zRotation = Random.Range(-zRotationMax, zRotationMax);

        transform.Rotate(xRotation, yRotation, zRotation);
    }
}