using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Obstacle {

    [SerializeField] private List<GridTile> path;
    [SerializeField] private float moveSpeed = 4f;
    private int pathCounter = 0;
    private bool reversing = false;

    public override void OnAttemptEnter()
    {
        throw new System.NotImplementedException();
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
        if (pathCounter < 0)
        {
            reversing = true;
        }
        else if (pathCounter >= path.Count)
        {
            reversing = false;
        }


        if (reversing)
        {
            myTile = path[pathCounter - 1];
            pathCounter--;
        }
        else
        {
            myTile = path[pathCounter + 1];
            pathCounter++;
        }

        GridTile oldTile = myTile.neighbourSouth; //Find old tile
        oldTile.UnbindMyObsticle(); //Unbind me
        this.transform.parent = myTile.transform;

        StartCoroutine(Move(myTile));   //Move to new tile
    }


    IEnumerator Move(GridTile targetTile)
    {
        while (Vector3.Distance(transform.position, targetTile.pointToStand.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

    }
}

