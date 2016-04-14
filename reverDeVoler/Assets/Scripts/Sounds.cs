using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    public AudioSource onOverSound;
    public AudioSource onStartSound;
    public AudioSource onBonusPicked;

    public AudioSource[] ambiants;


    public float minimumTimeNextPlay = 15;
    public float maximumTimeNextPlay = 20;

    private float elapsedTime = 0;
    private float nextTime    = 15;



    void Start () {
        Game.OnStart       += OnStart;
        Game.OnOver        += OnOver;
        Game.OnBonusPicked += OnBonusPicked;

        PlayRandomAmbiant();
        SetNextTime();
    }


    void OnStart () {
        onStartSound.Play();
    }


    void OnOver () {
        onOverSound.Play();
    }


    void OnBonusPicked () {
        onBonusPicked.Play();
    }


    void Update () {
        elapsedTime += Time.unscaledDeltaTime;

        if (elapsedTime >= nextTime) {
            elapsedTime -= nextTime;

            PlayRandomAmbiant();
            SetNextTime();
        }
    }


    void PlayRandomAmbiant () {
        int index = Random.Range(0, ambiants.Length);

        AudioSource source = ambiants[index];
        source.Play();
    }


    void SetNextTime () {
        nextTime = Random.Range(minimumTimeNextPlay, maximumTimeNextPlay);
    }
}