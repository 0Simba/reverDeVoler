using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public float fadeDuration;


    public  bool  show  = false;
    private float ratio = 1;


    void Start () {
        ratio = (show) ? 1 : 0;
        GetComponent<Renderer>().material.color = new Color (1, 1, 1, ratio);
    }


    void Update () {
        float sens = (show) ? 1 : -1;

        ratio += Time.deltaTime / fadeDuration * sens;
        ratio = Mathf.Min(1, Mathf.Max(0, ratio));

        GetComponent<Renderer>().material.color = new Color (1, 1, 1, ratio);
    }
}