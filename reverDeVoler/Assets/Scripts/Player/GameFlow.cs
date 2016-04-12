using UnityEngine;
using System.Collections;

public class GameFlow : MonoBehaviour {

    public bool inGame = false;


    void Awake () {
        Game.OnOver  += OnOver;
        Game.OnStart += OnStart;
    }


    void Update () {
        if (inGame) {
            GameUpdate();
        }
        else {
            MenuUpdate();
        }
    }


    void MenuUpdate () {
        Vector3 forward = Player.instance.head.forward;

        forward.x = 0;
        forward.Normalize();

        float angle = Mathf.Atan2(forward.y, forward.z);
        float ratio = Mathf.Min(1, Mathf.Max(0, angle * Mathf.Rad2Deg / 40));

        if (ratio == 1) {
            Game.Launch();
        }
    }


    void GameUpdate () {

    }


    void OnOver () {
        Game.SmoothPause();
        inGame = false;
    }


    void OnStart () {
        Game.SmoothUnpause();
        inGame = true;
    }
}