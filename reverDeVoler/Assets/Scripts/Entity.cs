using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public float minimumScale;
    public float maximumScale;
    public float spawnDuration;
    public float distForDeletion;

    private float targetScale;
    private bool  isDestroying = false;

    void Awake () {
        Game.OnOver += OwnDestroy;
    }

    void Update() {
        backCleaner();
    }

    public void backCleaner()
    {
        Vector3 HeadToThis = transform.position - Player.instance.head.position;
        HeadToThis.Normalize();

        Vector3 lookDirection = Player.instance.head.forward;

        float dotProduct = Vector3.Dot(lookDirection, HeadToThis);

        //Debug.Log(transform.position.magnitude);
        if (dotProduct < 0 /*&& transform.position.magnitude > distForDeletion*/)
        {
            OwnDestroy();
        }
    }


    void Start () {
        targetScale = Random.Range(minimumScale, maximumScale);

        transform.localScale = new Vector3(0, 0, 0);

        StartCoroutine(Grow());
    }


    public void OwnDestroy () {
        if (isDestroying) {
            return;
        }

        isDestroying = true;
        StartCoroutine(Shrink());
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