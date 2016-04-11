using UnityEngine;
using System.Collections;

public class GameDimension : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/

    static public Transform corner1;
    static public Transform corner2;




    /*====================================
    =            InstancePart            =
    ====================================*/

    public Transform instanceCorner1;
    public Transform instanceCorner2;

    void Start () {
        if (!instanceCorner1 || !instanceCorner2) {
            Debug.LogError("[Game Week] GameDimension.Start -> Missing corner");
            Destroy(this);
            return;
        }


        corner1 = instanceCorner1;
        corner2 = instanceCorner2;
    }
}