using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    static public Player instance;

    public Transform head;

    public Transform startPoint;

    void Start()
    {
        instance = this;
    }

    private void Awake () {
        Game.OnOver += Reset;
<<<<<<< HEAD
=======
        instance = this;
>>>>>>> c464c7dedad4c47f31e81abda2d75e0f92a0b8e5
    }


    public void Reset () {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }
}