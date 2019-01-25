using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {

    bool isready;
    List<string> keylist;
    int i;

	void Start () {
		
	}
	
	void Update () {

        if (Input.GetKeyDown("enter")){

            keylist = InputCollector.Instance.Getcurrentkeylist();

            for (i = 0; i < keylist.Count; i++)
            {
                switch (keylist[i])
                {
                    case "up"
            
                  
                }
            }






        }
	}
}
