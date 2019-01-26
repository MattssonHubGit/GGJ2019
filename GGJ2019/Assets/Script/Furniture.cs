using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : Obstacle {

    [SerializeField] private bool moveable = false;

    public override void OnEnter()
    {
        Debug.Log("You shouldn't be able to enter furniture!");
    }

    public override void OnAttemptEnter()
    {
        //If not movable, simply don't care
        if (moveable == true)
        {
            return;
        }


    }

    public override void OnExit()
    {
        Debug.Log("And stay out of the furniture!");
    }

    public override void OnAttemptExit()
    {
        Debug.Log("Yeah, get out of the furniture!");
    }

    public override void OnPlayerExecutes()
    {
        Debug.Log("Furniture doe snot care about your commands!");
    }
}
