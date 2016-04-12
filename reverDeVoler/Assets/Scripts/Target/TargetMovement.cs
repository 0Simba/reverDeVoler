﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetMovement : MonoBehaviour {

    public List<Vector3> waypoints;

    public float speed = 1;
    public float requiredDist = 1;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (waypoints.Count > 0)
        {
            Vector3 nextPoint = waypoints[0];
            Vector3 dir = (nextPoint - transform.position);
            if (dir.sqrMagnitude > 1)
            {
                dir = dir.normalized;
            }
            transform.position += dir * Time.deltaTime * speed;
            if ((nextPoint - transform.position).magnitude < requiredDist)
            {
                waypoints.RemoveAt(0);
                if (waypoints.Count == 0)
                {
                    waypoints.Add(Random.insideUnitSphere * 50 + Vector3.forward * 25 + Vector3.up * 30);
                }
            }
        }
        
	}
}