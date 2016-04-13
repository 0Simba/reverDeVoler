using UnityEngine;
using System.Collections;

public class EntityStatus : MonoBehaviour {

    public Transform startPoint;

    void Start () {
        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void OnStart () {
        gameObject.SetActive(true);
    }


    void OnOver () {
        gameObject.SetActive(false);
    }

}