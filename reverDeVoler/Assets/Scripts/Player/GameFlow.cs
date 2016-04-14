using UnityEngine;
using System.Collections;

public class GameFlow : MonoBehaviour {

    public  float timeoutBeforeNewGame = 1f;
    private float timeoutElapsedTime   = 0;



    void Awake () {
        Game.OnOver  += OnOver;
        Game.OnStart += OnStart;
    }


    void Update () {
        if (Game.state == Game.States.game) {
            GameUpdate();
        }
        else {
            MenuUpdate();
        }
    }


    void MenuUpdate () {
        if (timeoutElapsedTime < timeoutBeforeNewGame) {
            UpdateTimeoutRatio();
        }
        else {
            CheckLiftHeadRatio();
        }
    }


    void UpdateTimeoutRatio () {
        timeoutElapsedTime += Time.unscaledDeltaTime;
    }


    void CheckLiftHeadRatio () {
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
        Game.SmoothPause(0.1f);
        timeoutElapsedTime = 0;
    }


    void OnStart () {
        Game.SmoothUnpause(3f);
    }
}