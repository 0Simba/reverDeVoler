using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public  float fadeDuration;
    public  bool  show        = false;

    private float ratio       = 1;
    private bool  ratioForced = false; 



    void Start () {
        ratio = (show) ? 1 : 0;
        GetComponent<Renderer>().material.color = new Color (1, 1, 1, ratio);
    }


    void Update () {
        if (!ratioForced) {
            float sens = (show) ? 1 : -1;

            ratio += Time.unscaledDeltaTime / fadeDuration * sens;
            ratio = Mathf.Min(1, Mathf.Max(0, ratio));
        }

        ratioForced = false;

        GetComponent<Renderer>().material.color = new Color (1, 1, 1, ratio);
    }


    public void ForceRatio (float hopedRatio) {
        ratioForced = true;
        ratio       = hopedRatio;
    }
}