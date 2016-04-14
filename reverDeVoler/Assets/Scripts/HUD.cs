using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    void Awake () {
        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void OnStart () {
        GetComponent<Renderer>().material.color = new Color (1, 1, 1, 0);
    }


    void OnOver () {
        GetComponent<Renderer>().material.color = new Color (1, 1, 1, 1);
    }

}