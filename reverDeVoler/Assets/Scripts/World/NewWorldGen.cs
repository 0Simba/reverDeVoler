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
    public float finalObjectWaypointCount = 0;
    
	// Use this for initialization
	void Start () {
        nextObjectPos = Vector3.forward * distanceBetweenObstacle;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnObject.Count);
        while (spawnObject.Count < 4)
        {
            GameObject obj = Instantiate(GetRandomObject(), nextObjectPos, Quaternion.LookRotation(nextObjectPos - oldObjectPos)) as GameObject;
            CalculateNextPos();
            UpdateTargetPath(obj);
            spawnObject.Add(obj);
        }
        destroyOldObject();
    }

    void UpdateTargetPath(GameObject obj)
    {
        finalObjectWaypointCount = 0;
        List<Transform> targets = GetChildWithTag(obj.transform, "Target");
        foreach(Transform point in targets)
        {
            finalObjectWaypointCount++;
            target.waypoints.Add(point.position);
            Destroy(point.gameObject);
        }
    }

    void destroyOldObject()
    {
        if (target.waypoints.Count < finalObjectWaypointCount + 2)
        {
            GameObject first = spawnObject[0];
            Destroy(first);
            spawnObject.RemoveAt(0);
        }
    }
    
    void CalculateNextPos()
    {
        Vector3 forward = (nextObjectPos - oldObjectPos).normalized;
        Quaternion spe = Quaternion.Euler(0, Random.value * angleRot - angleRot * 0.5f, 0);
        Vector3 newForward = spe * forward;
        Debug.Log(spe);
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
