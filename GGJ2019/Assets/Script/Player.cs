﻿using System.Collections;
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

    private float currentTime=0;
    public float maxturntime =10;

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
                //Debug.Log("mvstate");
                TurnTimer();
                if (Input.GetKeyDown("return"))
                {
                    Debug.Log("execute!");
                    currentState = PlayerState.EXECUTING;
                }
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

    public bool skipRestOfMove = false;

    private void CommandControllerFix()
    {
        keylist = InputCollector.Instance.Getcurrentkeylist();
        Debug.Log("Firstelementofnewkeylist:" + keylist[0]);
        
        if (keylisttracker < keylist.Count)
        {
            //Every turn things
            skipRestOfMove = false;
            IconCollector.Instance.UpdateCommandList();
           /* for (int x = 0; x < GridGenerator.Instacne.level.GetLength(0); x++)
            {
                for (int y = 0; y < GridGenerator.Instacne.level.GetLength(1); y++)
                {
                    GridGenerator.Instacne.level[x, y].OnCommandExecute();
                }
            }*/

            switch (keylist[keylisttracker])
            {
                case "up":
                    {
                        if (currentTile.neighbourNorth != null)
                            targetTile = currentTile.neighbourNorth;
                        else
                        {
                            Debug.Log("Du försökte gå till en tile som ej existerar");
                            keylisttracker++;
                            break;
                        }

                        targetTile.OnAttemptEnter();
                        if (skipRestOfMove == false) //Skip rest of move
                        {
                            if (!targetTile.isBlocking)
                            {
                                currentState = PlayerState.WAITING;
                                StartCoroutine(Move(targetTile));

                            }
                            else
                            {
                                Debug.Log("Du försökte gå till en tile som är blockad");
                                keylisttracker++;
                                break;
                            }
                        }
                        else
                        {
                            keylisttracker++;
                        }


                        break;
                    }

                case "down":
                    {
                        if (currentTile.neighbourSouth != null)
                            targetTile = currentTile.neighbourSouth;
                        else
                        {
                            Debug.Log("Du försökte gå till en tile som ej existerar");
                            keylisttracker++;
                            break;
                        }

                        targetTile.OnAttemptEnter();

                        if (skipRestOfMove == false) //Skip rest of move
                        {
                            if (!targetTile.isBlocking)
                            {
                                currentState = PlayerState.WAITING;
                                StartCoroutine(Move(targetTile));

                            }
                            else
                            {
                                Debug.Log("Du försökte gå till en tile som är blockad");
                                keylisttracker++;
                                break;
                            }
                        }
                        else
                        {
                            keylisttracker++;
                        }


                        break;
                    }

                case "left":
                    {
                        if (currentTile.neighbourWest != null)
                            targetTile = currentTile.neighbourWest;
                        else
                        {
                            Debug.Log("Du försökte gå till en tile som ej existerar");
                            keylisttracker++;
                            break;
                        }

                        targetTile.OnAttemptEnter();
                        if (skipRestOfMove == false) //Skip rest of move
                        {
                            if (!targetTile.isBlocking)
                            {
                                currentState = PlayerState.WAITING;
                                StartCoroutine(Move(targetTile));

                            }
                            else
                            {
                                Debug.Log("Du försökte gå till en tile som är blockad");
                                keylisttracker++;
                                break;
                            }
                        }
                        else
                        {
                            keylisttracker++;
                        }


                        break;
                    }

                case "right":
                    {
                        if (currentTile.neighbourEast != null)
                            targetTile = currentTile.neighbourEast;
                        else
                        {
                            Debug.Log("Du försökte gå till en tile som ej existerar");
                            keylisttracker++;
                            break;
                        }

                        targetTile.OnAttemptEnter();
                        if (skipRestOfMove == false) //Skip rest of move
                        {
                            if (!targetTile.isBlocking)
                            {
                                currentState = PlayerState.WAITING;
                                StartCoroutine(Move(targetTile));

                            }
                            else
                            {
                                Debug.Log("Du försökte gå till en tile som är blockad");
                                keylisttracker++;
                                break;
                            }
                        }
                        else
                        {
                            keylisttracker++;
                        }
                        break;
                    }
                   
                case "space":
                    {
                        targetTile = currentTile;
                        currentState = PlayerState.WAITING;
                        StartCoroutine(Pause(targetTile));
                        break;
                    }
                   
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
    IEnumerator Pause(GridTile targetTile)
    {
        yield return new WaitForSecondsRealtime(1f);
        keylisttracker++;
        currentTile.OnAttemptEnter();
        currentState = PlayerState.EXECUTING;
    }
    private bool TurnTimer()
    {
        if (currentTime >= maxturntime)
        {
            return true
        }
        else
    }
}

