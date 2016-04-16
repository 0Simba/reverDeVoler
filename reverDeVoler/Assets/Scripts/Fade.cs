using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public  float fadeDuration;
    public  bool  show        = false;

    private float ratio       = 1;
    private bool  ratioForced = false;
    private Renderer _renderer;



    void Start () {
        ratio = (show) ? 1 : 0;
        _renderer = GetComponent<Renderer>();
        if ((ratio > 0.01) != _renderer.enabled)
        {
            _renderer.enabled = ratio > 0.01;
        }
        _renderer.material.color = new Color (1, 1, 1, ratio);
    }


    void Update () {
        if (!ratioForced) {
            float sens = (show) ? 1 : -1;

            ratio += Time.unscaledDeltaTime / fadeDuration * sens;
            ratio = Mathf.Min(1, Mathf.Max(0, ratio));
        }

        ratioForced = false;
        if ((ratio > 0.01) != _renderer.enabled)
        {
            _renderer.enabled = ratio > 0.01;
        }
        _renderer.material.color = new Color (1, 1, 1, ratio);
    }


    public void ForceRatio (float hopedRatio) {
        ratioForced = true;
        ratio       = hopedRatio;
    }
}