using UnityEngine;
using System.Collections;

public class InGameEnabler : MonoBehaviour {

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