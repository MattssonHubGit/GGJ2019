using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetselector : MonoBehaviour {

    public List<Target> targets;
    int targetnumber;

    // Use this for initialization
    void Start () {
        targetnumber = Random.Range(0, targets.Count);
        targets[targetnumber].isTarget = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
