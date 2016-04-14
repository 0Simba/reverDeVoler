using UnityEngine;
using System.Collections;

public class FloatingTile : MonoBehaviour
{

    public Texture[] textures;

    void Awake()
    {
        Game.OnStart += OnStart;
        Game.OnOver += OnOver;
        changeTitle();
    }


    void OnStart()
    { 
        GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
    }


    void OnOver()
    {
        changeTitle();
    }

    void changeTitle()
    {
        GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
        GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
    }
}