using UnityEngine;
using System.Collections;

public class EntityStatus : MonoBehaviour {

    public Transform startPoint;
    public Vector3 newDist;

    void Start () {
        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void OnStart () {
        gameObject.SetActive(true);
        transform.position = startPoint.position + newDist;
    }


    void OnOver () {
        gameObject.SetActive(false);
    }

}