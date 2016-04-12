using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    static public Player instance;

    public Transform head;

    public Transform startPoint;

    

    private void Awake () {
<<<<<<< HEAD
        Game.OnReset += Reset;
        instance = this;
=======
        Game.OnOver += Reset;
>>>>>>> d89149370404d7b98abe616384f5fde78c237031
    }


    public void Reset () {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }
}