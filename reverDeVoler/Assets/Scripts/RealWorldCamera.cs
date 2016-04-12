using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RealWorldCamera : MonoBehaviour {

    private WebCamTexture mCamera = null;


    void Start () {
        mCamera = new WebCamTexture ();
        mCamera.Play ();
        GetComponent<Renderer>().material.mainTexture = mCamera;
    }
}