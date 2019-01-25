using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour {
    
    [Header("Required Prefab Components")]
    public Transform pointToStand;

    [Header("Neighbours")]
    public GridTile neighbourNorth;
    public GridTile neighbourSouth;
    public GridTile neighbourEast;
    public GridTile neighbourWest;

    public List<GridTile> neighbours = new List<GridTile>();


    [Header("Accessibility")]
    public bool isBlocking = false;

}
