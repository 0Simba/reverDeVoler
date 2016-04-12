using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Transform startPoint;

    private void Awake () {
        Game.OnOver += Reset;
    }


    public void Reset () {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }
}