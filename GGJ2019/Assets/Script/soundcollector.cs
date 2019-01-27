using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcollector : MonoBehaviour {

    public AudioSource win;
    public AudioSource loose;

	// Use this for initialization
   public void Win()
    {
        win.Play();
    }
    public void Loose()
    {
        loose.Play();
    }
}
