﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollector : MonoBehaviour {

    List<string> keylist;
    public static InputCollector Instance;

    // Use this for initialization
    void Start() {
        keylist = new List<string>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("up"))
            keylist.Add("up");
        if (Input.GetKeyDown("down"))
            keylist.Add("down");
        if (Input.GetKeyDown("left"))
            keylist.Add("left");
        if (Input.GetKeyDown("right"))
            keylist.Add("right");
        if (Input.GetKeyDown("space"))
            keylist.Add("space");

    }

    public void Emptykeylist() {
        keylist.Clear();
    }

    public List<string> Getcurrentkeylist(){
        return keylist;
    }
}
