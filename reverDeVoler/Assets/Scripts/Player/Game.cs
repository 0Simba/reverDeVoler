using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/

    public delegate void ResetMethod ();

    static public Transform corner1;
    static public Transform corner2;

    static public event ResetMethod OnReset;

    static public void Over () {
        OnReset();
    }



    /*====================================
    =            InstancePart            =
    ====================================*/

    public Transform instanceCorner1;
    public Transform instanceCorner2;

    void Awake () {
        if (!instanceCorner1 || !instanceCorner2) {
            Debug.LogError("[Game Week] GameDimension.Start -> Missing corner");
            Destroy(this);
            return;
        }


        corner1 = instanceCorner1;
        corner2 = instanceCorner2;
    }


    void Start () {
        OnReset();
    }
}