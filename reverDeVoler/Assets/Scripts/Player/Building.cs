using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    void Awake () {
        Game.OnReset += OwnDestroy;
    }


    void OwnDestroy () {
        Game.OnReset -= OwnDestroy;
        Destroy(gameObject);
    }
}