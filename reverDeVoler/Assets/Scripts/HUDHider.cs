using UnityEngine;
using System.Collections;

public class HUDHider : MonoBehaviour {

    void Awake()
    {
        Game.OnStart += OnStart;
        Game.OnOver += OnOver;
    }


    void OnStart()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(1, 1, 1, 0);
        renderer.enabled = false;
    }


    void OnOver()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(1, 1, 1, 1);
        renderer.enabled = true;
    }
}

