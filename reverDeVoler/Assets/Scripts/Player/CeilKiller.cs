using UnityEngine;
using System.Collections;

public class CeilKiller : MonoBehaviour {

    public float yOffsetBeforeWarning = 1;
    public float warningRatio = 0;

    void Update () {
        float ceilShift = Game.corner2.position.y - transform.position.y;

        warningRatio = Mathf.Min(1, Mathf.Max(0, 1 - (ceilShift / yOffsetBeforeWarning)));

        if (warningRatio == 1) {
            Game.Over();
        }
    }

}