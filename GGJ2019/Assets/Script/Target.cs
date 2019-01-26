using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Obstacle {

    public override void OnAttemptEnter()
    {
        //if(player)
        win();
        
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
        throw new System.NotImplementedException();
    }

    public override void OnPlayerExecutes()
    {
        throw new System.NotImplementedException();
    }
    private void win()
    {
        Debug.Log("You won");
    }
}
