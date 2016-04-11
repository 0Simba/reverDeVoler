using UnityEngine;
using System.Collections;

public class PlayerParent : MonoBehaviour {

    protected Player player;


    protected void Start () {
        player = GetComponent<Player>();

        if (!player) {
            Debug.LogError("[GameWeek] PlayerCollide.Start -> no 'Player' component attached to gameObject");
            Destroy(this);
        }
    }
}