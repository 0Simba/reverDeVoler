using UnityEngine;
using System.Collections;

public class CeilKiller : MonoBehaviour {

    public float yOffsetBeforeWarning = 1;
    public float warningRatio = 0;
    public SandDune floor;

    void Update () {
        Vector3 playerPosition = transform.position;
        float ceilShift = Game.corner2.position.y - playerPosition.y;

        warningRatio = Mathf.Min(1, Mathf.Max(0, 1 - (ceilShift / yOffsetBeforeWarning)));

        if (warningRatio == 1) {
            Game.Over();
        }

        float floorLevel = floor.GetFloorLevel(playerPosition);
        if (playerPosition.y < floorLevel) {
            Game.Over();
        }
    }

}