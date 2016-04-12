using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public RawImage rawImage;


    void Start () {
        rawImage = GetComponent<RawImage>();
        Game.OnReset += FadeIn;

        rawImage.color = new Color (1, 1, 1, 1);

    }


    void FadeIn () {
        rawImage.color = new Color (1, 1, 1, 1);

        StartCoroutine(FadeOut());
    }


    IEnumerator FadeOut () {
        yield return new WaitForSeconds(0.5f);
        rawImage.color = new Color (1, 1, 1, 0);
    }
}