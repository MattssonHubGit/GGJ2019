using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [HideInInspector] public bool isBlocking = false;
    /*[HideInInspector]*/ public Vector2Int coordinates = new Vector2Int();

    #region Level editing
    [Header("Level")]
    [SerializeField] private Obstacle myObstacle = null;
    public UnityEvent SetUpObsticle;

    [ContextMenu("Set up Obsticles")]
    private void SetUpObsticles()
    {
        SetUpObsticle.Invoke();
    }

    public void AddBlocker(Obstacle obsticlePrefab)
    {
        Obstacle _obstacle = Instantiate(obsticlePrefab, pointToStand.position, Quaternion.identity, this.transform);
        isBlocking = _obstacle.blocks;
        _obstacle.myTile = this;
        myObstacle = _obstacle;
    }

    public void UnbindMyObsticle()
    {
        //myObstacle.transform.parent = null;
        myObstacle = null;
        isBlocking = false;
    }
    #endregion

    public void OnEnter()
    {
        if (myObstacle != null)
        {
            myObstacle.OnEnter();
        }
    }

    [ContextMenu("Try to enter")]
    public void OnAttemptEnter()
    {
        if (myObstacle != null)
        {
            myObstacle.OnAttemptEnter();
        }
    }

    public void OnExit()
    {
        if (myObstacle != null)
        {
            myObstacle.OnExit();
        }
    }
    public void OnAttemptExit()
    {
        if (myObstacle != null)
        {
            myObstacle.OnAttemptExit();
        }
    }

    public void OnCommandExecute()
    {
        if (myObstacle != null)
        {
            myObstacle.OnPlayerExecutes();
        }
    }

    [ContextMenu("PlayerDirectionDebug")]
    private void DebugPlayerDirection()
    {
        Debug.Log(Obstacle.PlayerComingFrom(GridGenerator.Instacne.activePlayer, this).ToString());
    }
}
