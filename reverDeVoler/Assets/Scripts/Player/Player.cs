using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    static public Player instance;

    public Transform head;
    public Transform startPoint;
    public float     lifeTime               = 10;
    public float     lifeBeforeStartWarning = 0;
    public Fade      realWorldFade;

    private float currentLifeTime; 


    private void Awake () {
        instance        = this;
        currentLifeTime = lifeTime;
        Game.OnOver     += Reset;

        if (!realWorldFade) {
            Debug.LogError("[Game Week] Player.Awake -> No realWorldFade set");
        }
    }


    public void Reset () {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;

        currentLifeTime = lifeTime;
    }


    public void BonusPicked () {
        currentLifeTime = lifeTime;
        Game.CallOnBonusPicked();
    }


    void Update () {
        currentLifeTime -= Time.deltaTime;

        if (currentLifeTime <= 0) {
            Game.Over();
        }
        else if (currentLifeTime < lifeBeforeStartWarning) {
            float ratio = 1 - (currentLifeTime / lifeBeforeStartWarning);

            realWorldFade.ForceRatio(ratio * 0.8f);
        }
    }
}