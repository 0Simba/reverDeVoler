using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RealWorldCamera : MonoBehaviour {

    private WebCamTexture mCamera = null;
    private Fade          fade;



    void Start () {
        mCamera = new WebCamTexture ();
        mCamera.Play ();
        GetComponent<Renderer>().material.mainTexture = mCamera;

        fade = GetComponent<Fade>();


        Game.OnStart += OnStart;
        Game.OnOver  += OnOver;
    }


    void OnOver () {
        fade.show = true;
    }


    void OnStart () {
        fade.show = false;
    }
}