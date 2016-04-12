using UnityEngine;
using System.Collections;

public class GameFlow : MonoBehaviour {

    void Awake () {
        Game.OnOver  += Pause;
        Game.OnStart += UnPause;
    }


    void Pause () {
        Game.SmoothPause();
    }


    void UnPause () {
        Game.SmoothUnpause();
    }
}