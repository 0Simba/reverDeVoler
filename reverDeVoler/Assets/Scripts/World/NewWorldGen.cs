using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewWorldGen : MonoBehaviour {

    public TargetMovement target;
    public List<GameObject> spawnObject;
    public GameObject[] obstacleSet;
    public float distanceBetweenObstacle;
    private Vector3 nextObjectPos = Vector3.forward;
    private Vector3 oldObjectPos = Vector3.zero;
    public float angleRot = 90;
    
	// Use this for initialization
	void Start () {
        nextObjectPos = Vector3.forward * distanceBetweenObstacle;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnObject.Count < 10)
        {
            GameObject obj = Instantiate(GetRandomObject(), nextObjectPos, Quaternion.LookRotation(nextObjectPos - oldObjectPos)) as GameObject;
            CalculateNextPos();
            UpdateTargetPath(obj);
            spawnObject.Add(obj);
        }
    }

    void UpdateTargetPath(GameObject obj)
    {
        List<Transform> targets = GetChildWithTag(obj.transform, "Target");
        foreach(Transform point in targets)
        {
            target.waypoints.Add(point.position);
        }
    }
    
    void CalculateNextPos()
    {
        Vector3 forward = (nextObjectPos - oldObjectPos).normalized;
        Quaternion spe = Quaternion.Euler(0, Random.value * angleRot - angleRot * 0.5f, 0);
        Vector3 newForward = spe * forward;
        oldObjectPos = nextObjectPos;
        nextObjectPos = nextObjectPos + newForward * distanceBetweenObstacle;
    }

    GameObject GetRandomObject()
    {
        return obstacleSet[Random.Range(0, obstacleSet.Length)];
    }

    List<Transform> GetChildWithTag(Transform obj, string tag) {
        List<Transform> list = new List<Transform>();
        if (obj.CompareTag(tag))
        {
            list.Add(obj);
        }
        foreach(Transform child in obj)
        {
            list.AddRange(GetChildWithTag(child, tag));
        }
        return list;
    }
}
