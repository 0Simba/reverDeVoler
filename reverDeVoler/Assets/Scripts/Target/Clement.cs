using UnityEngine;
using System.Collections;

public class Clement : MonoBehaviour {

    void Update () {
        transform.LookAt(Player.instance.transform);
    }


}