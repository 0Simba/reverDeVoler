using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/

    public delegate void  ResetMethod ();
    static public   event ResetMethod OnOver;
    static public   event ResetMethod OnStart;



    static public  Transform corner1;
    static public  Transform corner2;
    static private Game      instance;

    static public void Over () {
        OnOver();
    }


    static public void Launch () {
        OnStart();
    }


    static public void SmoothPause (float duration = 1f) {
        instance.SetSmoothPause(duration);
    }


    static public void SmoothUnpause (float duration = 1f) {
        instance.SetSmoothUnpause(duration);
    }



    /*====================================
    =            InstancePart            =
    ====================================*/

    public Transform instanceCorner1;
    public Transform instanceCorner2;

    void Awake () {
        instance = this;

        if (!instanceCorner1 || !instanceCorner2) {
            Debug.LogError("[Game Week] GameDimension.Start -> Missing corner");
            Destroy(this);
            return;
        }


        corner1 = instanceCorner1;
        corner2 = instanceCorner2;
    }


    void Start () {
        OnOver();
    }


    void SetSmoothPause (float duration) {
        StartCoroutine(SmoothPauseCoroutine(duration));
    }


    IEnumerator SmoothPauseCoroutine (float duration) {
        while (Time.timeScale > 0) {
            yield return null;

            Time.timeScale = Mathf.Max(Time.timeScale - Time.unscaledDeltaTime / duration, 0);
        }
    }


    void SetSmoothUnpause (float duration) {
        StartCoroutine(SmoothUnpauseCoroutine(duration));
    }


    IEnumerator SmoothUnpauseCoroutine (float duration) {
        while (Time.timeScale < 1) {
            yield return null;

            Time.timeScale = Mathf.Min(Time.timeScale + Time.unscaledDeltaTime / duration, 1);
        }
    }
}