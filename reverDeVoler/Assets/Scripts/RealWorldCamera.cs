using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RealWorldCamera : MonoBehaviour {

    private WebCamTexture mCamera = null;
    private Fade          fade;
    private CeilKiller    playerCeilKiller;


    void Start () {
        InitWebCamera();
        GetCeilKiller();
        fade       = GetComponent<Fade>();

        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void InitWebCamera () {
        mCamera = new WebCamTexture ();
        mCamera.Play ();
        GetComponent<Renderer>().material.mainTexture = mCamera;        
    }


    void GetCeilKiller () {
        playerCeilKiller = Player.instance.GetComponent<CeilKiller>();
        if (!playerCeilKiller) {
            Debug.LogError("[Game Week] RealWorldCamera.GetCeilKiller -> Player have not ceilKiller component");
            return;
        }
    }


    void OnOver () {
        fade.show = true;
    }


    void OnStart () {
        fade.show = false;
    }


    void Update () {
        if (Game.state == Game.States.game && playerCeilKiller.warningRatio > 0) {
            //fade.ForceRatio(playerCeilKiller.warningRatio / 2);
        }
    }
}