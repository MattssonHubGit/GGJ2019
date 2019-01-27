using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public AudioSource mainmusic;
    public List<AudioClip> files;
    private int clip = 0;

    // Use this for initialization
    void Start () {

        mainmusic.Play();


    }
	
	// Update is called once per frame
	void Update () {
    }
}
