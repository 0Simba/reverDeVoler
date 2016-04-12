using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RealWorldCamera : MonoBehaviour {

    private WebCamTexture mCamera = null;
    private RawImage      rawImage;

    void Start () {
        rawImage = GetComponent<RawImage>();

        mCamera = new WebCamTexture ();
        mCamera.Play ();
        rawImage.texture = mCamera;
    }
}