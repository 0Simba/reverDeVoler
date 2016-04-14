using UnityEngine;
using System.Collections;

public class DestroyOnOver : MonoBehaviour {

    void Start () {
        Game.OnOver += OnOver;
    }


    void OnOver () {
        Game.OnOver -= OnOver;
        Destroy(gameObject);
    }


}