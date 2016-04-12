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
        int index = Random.Range(0, prefabs.Length);

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