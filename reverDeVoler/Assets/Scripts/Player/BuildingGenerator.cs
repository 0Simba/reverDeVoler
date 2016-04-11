using UnityEngine;
using System.Collections;

public class BuildingGenerator : MonoBehaviour {

    public float      minimumBuildings = 10;
    public float      maximumBuildings = 100;
    public GameObject buildingPrefab;



    private void Awake () {
        Game.OnReset += Reset;
    }


    private void Reset () {
        float buildingsNumber = Random.Range(minimumBuildings, maximumBuildings);

        for (int i = 0; i < buildingsNumber; ++i) {
            Instantiate(buildingPrefab, GetRandomPosition(), Quaternion.identity);
        }
    }


    private Vector3 GetRandomPosition () {
        float x = Random.Range(Game.corner1.position.x, Game.corner2.position.x);
        float z = Random.Range(Game.corner1.position.z, Game.corner2.position.z);

        return new Vector3(x, 0, z);
    }

}