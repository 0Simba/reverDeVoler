using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public float minimumScale;
    public float maximumScale;
    public float spawnDuration;
    public float distForDeletion;
    public float lifeTime = 10;

    private float targetScale;
    private bool  isDestroying = false;



    void Awake () {
        Game.OnOver += OwnDestroy;
    }


    void Start () {
        Init();
    }


    protected void Init () { // Impossible unity error
        targetScale = Random.Range(minimumScale, maximumScale);
        transform.localScale = new Vector3(0, 0, 0);
        StartCoroutine(Grow());
    }



    void Update() {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0) {
            OwnDestroy();
        }
    }



    public void OwnDestroy () {
        if (isDestroying) {
            return;
        }

        isDestroying = true;
        StartCoroutine(Shrink());
    }


    public void InstantOwnDestroy()
    {
        if (isDestroying)
        {
            return;
        }

        isDestroying = true;
        Destroy(gameObject);
    }



    IEnumerator Shrink () {
        Game.OnOver -= OwnDestroy;

        float elapsedTime = 0;

        while (elapsedTime < spawnDuration) {
            elapsedTime += Time.unscaledDeltaTime;

            float ratio = 1 - Mathf.Min(1, elapsedTime / spawnDuration);
            float scale = targetScale * ratio;

            transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }

        Destroy(gameObject);
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