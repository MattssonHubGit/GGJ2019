using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GridTile currentTile = null;
    Transform targetPos;

    public void Moveto(GridTile targetTile)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, Time.deltaTime)
    
    }
}
