using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Obstacle {

    public bool isTarget = false;
    public Player player;
    public InputCollector inputCollector;

    public override void OnAttemptEnter()
    {
        if (isTarget)
        {
            win();


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
        throw new System.NotImplementedException();
    }

    public override void OnPlayerExecutes()
    {
        throw new System.NotImplementedException();
    }
    public void win()
    {
        Debug.Log("You won");
        inputCollector.Emptykeylist();
        player.currentState = Player.PlayerState.MVSELECT;
        player.keylisttracker = -1;
    }
    public void loose(){
        Debug.Log("Du förlorade men detta är inte implementerat");
        //gameoverscrreen och reload scene
    }
}
