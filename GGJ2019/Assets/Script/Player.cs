using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GridTile currentTile = null;
    Transform targetPos;
    public GridTile targetTile;
    List<string> keylist;
    int i;
    public int keylisttracker;
    [Header("actual variables")]
    [SerializeField] private float moveSpeed = 4;

    public enum PlayerState { WAITING, EXECUTING, MVSELECT};
    public PlayerState currentState;

    void Start()
    {
        int keylisttracker = 0;
        currentState = PlayerState.MVSELECT;
    }

    void Update()
    {

        switch (currentState)
        {
            case PlayerState.WAITING:
                break;
            case PlayerState.EXECUTING:
                CommandControllerFix();
                break;
            case PlayerState.MVSELECT:
                if (Input.GetKeyDown("return"))
                    currentState = PlayerState.EXECUTING;
                    break;
            default:
                break;
        }

    }
    IEnumerator Move(GridTile targetTile)
    {
        while (Vector3.Distance(transform.position, targetTile.pointToStand.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, moveSpeed*Time.deltaTime);
            yield return null;
        }
        
        keylisttracker++;
        Debug.Log("Movment Step Completed");
        currentTile = targetTile;
        yield return new WaitForSecondsRealtime(0.5f);
        currentState = PlayerState.EXECUTING;
        
    }


    private void CommandControllerFix()
    {
        keylist = InputCollector.Instance.Getcurrentkeylist();
        
        if (keylisttracker < keylist.Count)
        {
            switch (keylist[keylisttracker])
            {
                case "up":
                    if (currentTile.neighbourNorth != null)
                        targetTile = currentTile.neighbourNorth;
                    else
                    {
                        Debug.Log("Du försökte gå till en tile som ej existerar");
                        keylisttracker++;
                        break;
                    }
                    if (!targetTile.isBlocking)
                    {
                        currentState = PlayerState.WAITING;
                        StartCoroutine(Move(targetTile));

                    }

                    break;
                case "down":
                    if(currentTile.neighbourSouth != null)
                        targetTile = currentTile.neighbourSouth;
                    else
                    {
                        Debug.Log("Du försökte gå till en tile som ej existerar");
                        keylisttracker++;
                        break;
                    }
                    if (!targetTile.isBlocking)
                    {
                        currentState = PlayerState.WAITING;
                        StartCoroutine(Move(targetTile));

                    }
                    break;
                case "left":
                    if (currentTile.neighbourWest != null)
                        targetTile = currentTile.neighbourWest;
                    else
                    {
                        Debug.Log("Du försökte gå till en tile som ej existerar");
                        keylisttracker++;
                        break;
                    }
                    if (!targetTile.isBlocking)
                    {
                        currentState = PlayerState.WAITING;
                        StartCoroutine(Move(targetTile));

                    }
                    break;
                case "right":
                    if (currentTile.neighbourEast != null)
                        targetTile = currentTile.neighbourEast;
                    else
                    {
                        Debug.Log("Du försökte gå till en tile som ej existerar");
                        keylisttracker++;
                        break;
                    }
                    if (!targetTile.isBlocking)
                    {
                        currentState = PlayerState.WAITING;
                        StartCoroutine(Move(targetTile));

                    }

                    break;
                case "space":

                    break;
                default:
                    print("skumma saker hände");
                    break;


            }
        }
    }
    public bool IsMVSELECT()
    {
        if (currentState == PlayerState.MVSELECT)
            return true;
        else
            return false;
    }
}
