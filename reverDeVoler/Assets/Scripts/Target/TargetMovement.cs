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
    public  GameObject    bonus;

    private Transform     startPoint;
    private Transform     player;
    private float         minMaxGap;


    void Start () {
        Game.OnStart += OnStart;
        Game.OnOver  += Reset;
        minMaxGap    = playerDistanceMaximum - playerDistanceMinimum;
    }


    void OnEnable () {
        OnStart();
    }


    void OnStart () {
        transform.position = Player.instance.startPoint.position + startOffset;

        Debug.Log(transform.position);
    }

	
	void Update () {
        if (waypoints.Count == 0) {
            return;
        }


        Vector3 nextPoint = waypoints[0];
        Vector3 direction = (nextPoint - transform.position);

        transform.LookAt(nextPoint);

        MoveFromDirection(direction.normalized);

        if ((nextPoint - transform.position).magnitude < requiredDist) {
            SetNextWayPoint();
            AddBonus();
        }
	}


    void MoveFromDirection (Vector3 direction) {
        Vector3 playerPosition = Player.instance.transform.position; 
        float   playerDistance = (transform.position - playerPosition).magnitude;
        float   ratio          = 1 - (playerDistance - playerDistanceMinimum) / minMaxGap;

        ratio = Mathf.Min(1, Mathf.Max(0, ratio));

        transform.position += direction * Time.deltaTime * MaxSpeed * ratio;
    }


    void SetNextWayPoint () {
        waypoints.RemoveAt(0);

        if (waypoints.Count == 0) {
            waypoints.Add(Random.insideUnitSphere * 50 + Vector3.forward * 25 + Vector3.up * 30);
        }        
    }


    void Reset() {
        waypoints.Clear();
    }


    void AddBonus () {
        Instantiate(bonus, transform.position, Quaternion.identity);
    }
}
