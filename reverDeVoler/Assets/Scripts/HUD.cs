using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    void Awake () {
        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void OnStart () {
        Debug.Log("hide");
        GetComponent<Renderer>().material.color = new Color (1, 1, 1, 0);
    }


    void OnOver () {
        Debug.Log("show");
        GetComponent<Renderer>().material.color = new Color (1, 1, 1, 1);
    }

}