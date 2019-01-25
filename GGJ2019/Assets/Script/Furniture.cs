using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : Obsticle {

    [SerializeField] private bool eternal = false;

    public override void OnEnter()
    {
        Debug.Log("You shouldn't be able to enter furniture!");
    }

    public override void OnAttemptEnter()
    {
        Debug.Log("You can't enter furniture!");
    }

    public override void OnExit()
    {
        Debug.Log("And stay out of the furniture!");
    }

    public override void OnAttemptExit()
    {
        Debug.Log("Yeah, get out of the furniture!");
    }
}
