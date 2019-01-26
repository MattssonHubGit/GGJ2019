using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : Obstacle
{

    [SerializeField] private bool moveable = false;

    public override void OnEnter()
    {
        Debug.Log("You shouldn't be able to enter furniture!");
    }

    public override void OnAttemptEnter()
    {
        //If not movable, simply don't care
        if (moveable == false)
        {
            return;
        }

        CardinalDirections.Directions playerComesFrom = PlayerComingFrom(GridGenerator.Instacne.activePlayer, myTile);

        //Go north
        if (playerComesFrom == CardinalDirections.Directions.S) //Player coming from south
        {
            if (myTile.neighbourNorth != null) //my tile has a nothern neighbour
            {
                if (myTile.neighbourNorth.isBlocking == false)
                {
                    myTile = myTile.neighbourNorth; //Change tile

                    GridTile oldTile = myTile.neighbourSouth; //Find old tile
                    oldTile.UnbindMyObsticle(); //Unbind me
                    this.transform.parent = myTile.transform;

                    StartCoroutine(MoveThingToPosition(myTile));   //Move to new tile
                }
            }
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


    private IEnumerator MoveThingToPosition(GridTile targetTile)
    {
        while (Vector3.Distance(transform.position, targetTile.pointToStand.position) > 0.01f)
        {
            Debug.Log(transform.position);
            transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, Time.deltaTime);
            yield return null;
        }
    }

}
