using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public  float    fadeDuration; 
    private RawImage rawImage;


    void Start () {
        rawImage = GetComponent<RawImage>();
        Game.OnReset += DeathFadeAnimation;

        rawImage.color = new Color (1, 1, 1, 0);
    }


    void DeathFadeAnimation () {
        StartCoroutine(DeathFadeAnimationCoroutine());
    }


    IEnumerator DeathFadeAnimationCoroutine () {
        StartCoroutine(FadeInCoroutine());
        yield return new WaitForSeconds(fadeDuration * 2);
        StartCoroutine(FadeOutCoroutine());
    }


    void FadeIn () {
        StartCoroutine(FadeOutCoroutine());
    }


    IEnumerator FadeInCoroutine () {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;

            float ratio = Mathf.Min(1, elapsedTime / fadeDuration);
            rawImage.color = new Color (1, 1, 1, ratio);

            yield return null;
        }
    }


    IEnumerator FadeOutCoroutine () {
        Debug.Log("dans le fade out");
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;

            float ratio = Mathf.Min(1, elapsedTime / fadeDuration);
            rawImage.color = new Color (1, 1, 1, 1 - ratio);

            yield return null;
        }    
    }

}