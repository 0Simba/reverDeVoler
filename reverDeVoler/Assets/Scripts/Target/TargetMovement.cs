using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetMovement : MonoBehaviour {

    public  List<Vector3> waypoints;
    public  Vector3       startOffset;
    public  float         speed        = 1;
    public  float         requiredDist = 1;
    public  float         playerDistanceMinimum;
    public  float         playerDistanceMaximum;
    private Transform     startPoint;
    private Transform     player;



    void Start () {
        Game.OnStart += OnStart;
        startPoint = Player.instance.head;
    }


    void OnStart () {
        transform.position = startPoint.position + startOffset;
    }

	
	void Update () {
        if (waypoints.Count == 0) {
            return;
        }


        Vector3 nextPoint = waypoints[0];
        Vector3 direction = (nextPoint - transform.position);

        MoveFromDirection(direction.normalized);

        if ((nextPoint - transform.position).magnitude < requiredDist) {
            SetNextWayPoint();
        }
	}


    void MoveFromDirection (Vector3 direction) {
        transform.position += direction * Time.deltaTime * speed;
    }


    void SetNextWayPoint () {
        waypoints.RemoveAt(0);

        if (waypoints.Count == 0) {
            waypoints.Add(Random.insideUnitSphere * 50 + Vector3.forward * 25 + Vector3.up * 30);
        }        
    }
}
