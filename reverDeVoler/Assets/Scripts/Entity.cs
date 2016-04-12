using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public float minimumScale;
    public float maximumScale;
    public float spawnDuration;

    private float targetScale;
    private bool  isDestroying = false;

    void Awake () {
        Game.OnReset += Reset;
    }


    void Start () {
        targetScale = Random.Range(minimumScale, maximumScale);
        transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(Grow());
    }


    public void OwnDestroy () {
        Game.OnReset -= Reset;
        if (isDestroying) {
            return;
        }
        Debug.Log(this.name);
        isDestroying = true;
        StartCoroutine(Shrink());
    }

    public void Reset()
    {
        Game.OnReset -= Reset;
        Destroy(gameObject);
    }

    IEnumerator Shrink () {
        float elapsedTime = 0;

        while (elapsedTime < spawnDuration) {
            elapsedTime += Time.deltaTime;

            float ratio = 1 - Mathf.Min(1, elapsedTime / spawnDuration);
            float scale = targetScale * ratio;

            transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }

        Destroy(gameObject);
        Game.OnReset -= OwnDestroy;
    }



    IEnumerator Grow () {
        float elapsedTime = 0;

        while (elapsedTime < spawnDuration) {
            elapsedTime += Time.deltaTime;

            float ratio = Mathf.Min(1, elapsedTime / spawnDuration);
            float scale = targetScale * ratio;

            transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }
    }
}