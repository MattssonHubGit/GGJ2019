using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetselector : MonoBehaviour {

    public List<Target> targets;
    int targetnumber;
    int oldNumber;

    public static Targetselector Instance;

    // Use this for initialization
    void Start () {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Randomize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Randomize()
    {
        while (oldNumber == targetnumber)
        {
            targetnumber = Random.Range(0, targets.Count);
        }
        oldNumber = targetnumber;
        ObjectiveText.Instance.textToEdit.text = targets[targetnumber].goalText;
        targets[targetnumber].isTarget = true;
        Debug.Log("target is " + targetnumber);
    }
}
