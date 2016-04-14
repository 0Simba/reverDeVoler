using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour
{

    public float xSpawnOffset = 3f;
    public float ySpawnOffset = 3f;
    public float spawnFrequence = 2;
    public float spawnFrequenceDivider = 1.1f;
    public GameObject[] obstacles;
    public int[] obstaclesScores;


    private float elapsedTime;
    private float spawnDuration;
    private bool spawnEnable = true;


    void Start()
    {
        spawnDuration = spawnFrequence;
        Game.OnStart += OnStart;
    }


    void OnStart()
    {
        spawnDuration = spawnFrequence;
        spawnEnable = true;
    }


    void Update()
    {
        if (!spawnEnable)
        {
            return;
        }


        elapsedTime += Time.deltaTime;

        if (elapsedTime > spawnDuration)
        {
            elapsedTime -= spawnDuration;
            spawnDuration /= spawnFrequenceDivider;

            Spawn();
        }
    }


    void Spawn()
    {
        float xOffset = Random.Range(-xSpawnOffset, xSpawnOffset);
        float yOffset = Random.Range(-ySpawnOffset, ySpawnOffset);
        Vector3 spawnPoint = transform.position;

        spawnPoint += transform.right * xOffset;
        spawnPoint += transform.up * yOffset;

        GameObject obstacle = GetRandomObstacle();

        Instantiate(obstacle, spawnPoint, transform.rotation);
    }


    private GameObject GetRandomObstacle()
    {
        int index = 0;
        int totalScore = 0;
        int[] incrementedScore = new int[obstaclesScores.Length];


        for (int i = 0; i < obstaclesScores.Length; ++i)
        {
            totalScore += obstaclesScores[i];
            incrementedScore[i] = totalScore;
        }


        int randomScore = Random.Range(0, totalScore + 1);

        for (int i = 0; i < incrementedScore.Length; ++i)
        {
            if (randomScore < incrementedScore[i])
            {
                index = i;
                break;
            }
        }

        return obstacles[index];
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObstacleEnabler")
        {
            spawnEnable = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ObstacleEnabler")
        {
            spawnEnable = true;
        }
    }

}