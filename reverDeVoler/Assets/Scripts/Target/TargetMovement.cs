using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetMovement : MonoBehaviour {

    public  List<Vector3> waypoints;
    public  Vector3       startOffset;
    public  float         MaxSpeed     = 1;
    public  float         requiredDist = 1;
    public  float         playerDistanceMinimum;
    public  float         playerDistanceMaximum;

    private Transform     startPoint;
    private Transform     player;
    private float         minMaxGap;


    void Start () {
        Game.OnStart += OnStart;
        startPoint = Player.instance.head;

        minMaxGap  = playerDistanceMaximum - playerDistanceMinimum;
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
        Vector3 playerPosition = Player.instance.transform.position; 
        float   playerDistance = (transform.position - playerPosition).magnitude;
        float   ratio          = 1 - (playerDistance - playerDistanceMinimum) / minMaxGap;

        ratio = Mathf.Min(1, Mathf.Max(0, ratio));

        Debug.Log(ratio);

        transform.position += direction * Time.deltaTime * MaxSpeed * ratio;
    }


    void SetNextWayPoint () {
        waypoints.RemoveAt(0);

        if (waypoints.Count == 0) {
            waypoints.Add(Random.insideUnitSphere * 50 + Vector3.forward * 25 + Vector3.up * 30);
        }        
    }
}
