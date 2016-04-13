using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    public AudioSource onOverSound;
    public AudioSource onStartSound;



    void Start () {
        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void OnStart () {
        onStartSound.Play();
    }


    void OnOver () {
        onOverSound.Play();
    }


}