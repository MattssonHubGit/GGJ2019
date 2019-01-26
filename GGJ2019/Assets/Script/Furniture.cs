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

                    StartCoroutine(MoveThingToPosition(this.transform, myTile.pointToStand.position, 1f));   //Move to new tile
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


    private IEnumerator MoveThingToPosition(Transform movingThing, Vector3 targetPosition, float timeInSec)
    {
        Vector3 startPos = movingThing.position;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / timeInSec)
        {
            Vector3 _newPos = Vector3.Lerp(startPos, targetPosition, t + Time.deltaTime / timeInSec);
            movingThing.position = _newPos;
            yield return null;
        }
    }

}
