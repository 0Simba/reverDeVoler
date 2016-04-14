using UnityEngine;
using System.Collections;

public class PropsGenerator : MonoBehaviour {

    public float minimumXOffset = 3;
    public float maximumXOffset = 10;
    public float minimumYOffset = 3;
    public float maximumYOffset = 10;
    public float minimumZOffset = 5;
    public float maximumZOffset = 15;

    public float spawnFrequence = 0.2f;

    public GameObject[] propsList;

    private float elapsedTime = 0;



    void Update () {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > spawnFrequence) {
            elapsedTime -= spawnFrequence;

            Vector3    spawnPosition = RandomSpawnPosition();
            GameObject props         = RandomProps();
            Quaternion spawnRotation = RandomRotation();

            Instantiate(props, spawnPosition, spawnRotation);
        }
    }


    Vector3 RandomSpawnPosition () {
        float xOffset = Random.Range(minimumXOffset, maximumXOffset) * RandomSign();
        float yOffset = Random.Range(minimumYOffset, maximumYOffset) * RandomSign();
        float zOffset = Random.Range(minimumZOffset, maximumZOffset) * RandomSign();

        Vector3 spawnPoint = transform.position;
        spawnPoint += transform.right   * xOffset;
        spawnPoint += transform.up      * yOffset;
        spawnPoint += transform.forward * zOffset;

        return spawnPoint;
    }


    GameObject RandomProps () {
        int index = Random.Range(0, propsList.Length);
        return propsList[index];
    }


    Quaternion RandomRotation () {
        return Quaternion.Euler(0, Random.Range(0, 360), Random.Range(0, 20));
    }


    int RandomSign () {
        return (Random.Range(0, 2) == 1) ? 1 : -1;
    }
}