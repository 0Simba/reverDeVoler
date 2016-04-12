using UnityEngine;
using System.Collections;

public class ElementGenerator : MonoBehaviour {


    public Transform    head;
    public float        distanceMinimumToSpawn;
    public float        distanceMaximumToSpawn;
    public float        minimumTimeBeforSpawn;
    public float        maximumTimeBeforSpawn;
    public GameObject[] prefabs;
    public float        apertureAngle           = 45;
    public int[] prefabScore;

    private float elapsedTime;
    private float durationBeforeNextSpawn;



    void Start () {
        SetNewSpawnWaiting();
    }


    void Update () {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= durationBeforeNextSpawn) {
            Spawn();
            SetNewSpawnWaiting();
        }
    }


    void  SetNewSpawnWaiting () {
        elapsedTime = 0;
        durationBeforeNextSpawn = Random.Range(minimumTimeBeforSpawn, maximumTimeBeforSpawn);
    }


    void Spawn () {
        Vector3    spawnPosition = GetRandomSpawnPosition();
        GameObject prefab        = GetRandomPrefab();

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }



    private GameObject GetRandomPrefab () {

        int totalScore=0;
        int index = 0;

        int[] incrementedScore = new int[prefabScore.Length];


        for (int i = 0; i < prefabScore.Length; ++i)
        {
            totalScore += prefabScore[i];
            incrementedScore[i] = totalScore;
        }

        int randomScore = Random.Range(0, totalScore+1);

        if (randomScore < incrementedScore[0])
        {
            index = 0;
        }

        if (randomScore > incrementedScore[0])
        {
            index = 1;
        }

        return prefabs[index];
    }


    private Vector3 GetRandomSpawnPosition () {
        float   distance    = Random.Range(distanceMinimumToSpawn, distanceMaximumToSpawn);
        Vector3 offsetSpawn = head.forward * distance;
        float   yRotation   = Random.Range(-apertureAngle, apertureAngle);
        float   xRotation   = Random.Range(-apertureAngle, apertureAngle);

        offsetSpawn = Quaternion.Euler(xRotation, yRotation, 0) * offsetSpawn;

        return offsetSpawn + head.position;
    }
}