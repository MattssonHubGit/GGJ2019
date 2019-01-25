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
    public bool isBlocking = false;

    #region Level editing
    [Header("Level")]
    [SerializeField] private Obsticle myObsticle = null;
    public UnityEvent SetUpObsticle;

    [ContextMenu("Set up Obsticles")]
    private void SetUpObsticles()
    {
        SetUpObsticle.Invoke();
    }

    public void AddBlocker(Obsticle obsticlePrefab)
    {
        Obsticle _obsticle = Instantiate(obsticlePrefab, pointToStand.position, Quaternion.identity, this.transform);
        isBlocking = _obsticle.blocks;
        myObsticle = _obsticle;
    }
    #endregion

    public void OnEnter()
    {
        if (myObsticle != null)
        {
            myObsticle.OnEnter();
        }
    }

    public void OnAttemptEnter()
    {
        if (myObsticle != null)
        {
            myObsticle.OnAttemptEnter();
        }
    }

    public void OnExit()
    {
        if (myObsticle != null)
        {
            myObsticle.OnExit();
        }
    }
    public void OnAttemptExit()
    {
        if (myObsticle != null)
        {
            myObsticle.OnAttemptExit();
        }
    }
}
