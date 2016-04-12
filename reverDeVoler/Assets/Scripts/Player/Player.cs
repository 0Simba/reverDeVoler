using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    static public Player instance;

    public Transform head;
    public Transform startPoint;

     private void Awake () {
        instance = this;
        Game.OnOver += Reset;
    }


    public void Reset () {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }
}