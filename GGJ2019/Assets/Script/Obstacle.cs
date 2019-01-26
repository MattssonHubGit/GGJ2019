using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour {

    public GridTile myTile;
    public bool blocks = true;

    public abstract void OnEnter();
    public abstract void OnAttemptEnter();
    public abstract void OnExit();
    public abstract void OnAttemptExit();
    public abstract void OnPlayerExecutes();

    public static CardinalDirections.Directions PlayerComingFrom(Player _player, GridTile targetTile)
    {
        CardinalDirections.Directions output = CardinalDirections.Directions.N;

        //East
        if (targetTile.neighbourEast != null)
        {
            if (_player.currentTile == targetTile.neighbourEast)
            {
                output = CardinalDirections.Directions.E;
                return output;
            }
        }
        
        //West
        if (targetTile.neighbourWest != null)
        {
            if (_player.currentTile == targetTile.neighbourWest)
            {
                output = CardinalDirections.Directions.W;
                return output;
            }
        }       
        
        //North
        if (targetTile.neighbourNorth != null)
        {
            if (_player.currentTile == targetTile.neighbourNorth)
            {
                output = CardinalDirections.Directions.N;
                return output;
            }
        }        
        
        //South
        if (targetTile.neighbourSouth != null)
        {
            if (_player.currentTile == targetTile.neighbourSouth)
            {
                output = CardinalDirections.Directions.S;
                return output;
            }
        }

        #region Legacy
        /*Debug.Log("Player: " + _player.name);
        Debug.Log("PlayerTile: " + _player.currentTile.name);
        Debug.Log("x: " + gridX + ", y: " + gridY);


        //East
        if (_player.currentTile.coordinates.x == gridX + 1 && _player.currentTile.coordinates.y != gridY)
        {
            output = CardinalDirections.Directions.E;
            return output;
        }

        //West
        if (_player.currentTile.coordinates.x == gridX - 1 && _player.currentTile.coordinates.y != gridY)
        {
            output = CardinalDirections.Directions.W;
            return output;
        }

        //North
        if (_player.currentTile.coordinates.y == gridY + 1 && _player.currentTile.coordinates.x != gridX)
        {
            output = CardinalDirections.Directions.N;
            return output;
        }

        //West  
        if (_player.currentTile.coordinates.y == gridY - 1 && _player.currentTile.coordinates.x != gridX)
        {
            output = CardinalDirections.Directions.S;
            return output;
        }*/
        #endregion

        Debug.LogError("Player Coming from unkown direction, outputting North");
        return output;
    }
}
