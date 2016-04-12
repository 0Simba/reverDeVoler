using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public  float fadeDuration; 

    void Start () {
        Game.OnOver += DeathFadeAnimation;

        GetComponent<Renderer>().material.color = new Color (1, 1, 1, 0);
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
            GetComponent<Renderer>().material.color = new Color (1, 1, 1, ratio);

            yield return null;
        }
    }


    IEnumerator FadeOutCoroutine () {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;

            float ratio = Mathf.Min(1, elapsedTime / fadeDuration);
            GetComponent<Renderer>().material.color = new Color (1, 1, 1, 1 - ratio);

            yield return null;
        }    
    }
}