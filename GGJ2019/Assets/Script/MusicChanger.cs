using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChanger : Obstacle {

    public string goalText = "";
    public Player player;
    public InputCollector inputCollector;

    public AudioClip file1;
    public AudioClip file2;
    public AudioSource source1;
    public AudioSource source2;


    void start(){
        //source1.Play();
    }

    public override void OnAttemptEnter()
    {

        if (source1.isPlaying) {
            source1.Pause();
            source2.Play();
        }
        else
        {
            source2.Pause();
            source1.Play();
        }
    }

    public override void OnAttemptExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnter()
    {
        if (source1.isPlaying)
        {
            source1.Pause();
            source2.Play();
        }
        else
        {
            source2.Pause();
            source1.Play();
        }
    }

    public override void OnPlayerExecutes()
    {
        throw new System.NotImplementedException();
    }
}
