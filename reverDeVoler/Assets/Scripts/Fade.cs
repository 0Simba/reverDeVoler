using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    public Image image;



    void Start () {
        image = GetComponent<Image>();
        Game.OnReset += FadeIn;

        image.color = new Color (1, 1, 1, 1);

    }


    void FadeIn () {
        image.color = new Color (1, 1, 1, 1);

        StartCoroutine(FadeOut());
    }


    IEnumerator FadeOut () {
        yield return new WaitForSeconds(0.5f);
        image.color = new Color (1, 1, 1, 0);
    }
}