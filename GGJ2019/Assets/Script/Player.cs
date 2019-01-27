using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GridTile currentTile = null;
    public InputCollector inputCollector;
    Transform targetPos;
    public GridTile targetTile;
    List<string> keylist;
    int i;
    public int keylisttracker;
    [Header("actual variables")]
    [SerializeField] private float moveSpeed = 4;
    public GameObject GameOverScreen;
    public Animator myAnime;

    public int score;
    public float timeleft;
    private int timesScored;
    private int multiplier;
    public int roundsToDoubleMultiplier = 4;

    private float currentTime = 0;
    public float maxturntime = 10;
    public float minmaxturntime = 3;
    bool timeout = false;

    public enum PlayerState { WAITING, EXECUTING, MVSELECT};
    public PlayerState currentState;

    void Start()
    {
        myAnime.SetBool("Walk", false);
        score = 0;
        multiplier = 1;
        timesScored = 0;
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
                if (inputCollector.keylist.Count < 1)
                    loose();
                CommandControllerFix();
                break;
            case PlayerState.MVSELECT:
                //Debug.Log("mvstate");
                
                if (Input.GetKeyDown("return") || TurnTimer())
                {
                    if (inputCollector.keylist.Count < 1)
                        loose();

                        
                    currentTime = 0;
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
        myAnime.SetBool("Walk", true);
        while (Vector3.Distance(transform.position, targetTile.pointToStand.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, moveSpeed*Time.deltaTime);
            transform.LookAt(targetTile.pointToStand.position);
            yield return null;
        }
        myAnime.SetBool("Walk", false);

        keylisttracker++;
        Debug.Log("Movment Step Completed");
        currentTile = targetTile;
        //yield return new WaitForSecondsRealtime(0.5f);
        currentState = PlayerState.EXECUTING;

    }

    public bool skipRestOfMove = false;

    private void CommandControllerFix()
    {
        keylist = InputCollector.Instance.Getcurrentkeylist();
        
        if (keylisttracker < keylist.Count)
        {
            //Every turn things
            skipRestOfMove = false;
            IconCollector.Instance.UpdateCommandList();
            //foreach (GridTile _tile in GridGenerator.Instacne.allTilesLifeSuck)
            //{
            //    _tile.OnCommandExecute();
            //}

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
            if (keylisttracker >= inputCollector.keylist.Count - 1)
            {

                Debug.Log("keylisttracker == inputCollector.keylist.Count - 1");
                inputCollector.Emptykeylist();
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
            currentTime = 0;
            return true;
        }
        else {
            currentTime += Time.deltaTime;
            timeleft = maxturntime - currentTime;
            return false;
             }
    }
    public void win()
    {
        Debug.Log("You won");
        Targetselector.Instance.Randomize();
        inputCollector.Emptykeylist();
        keylisttracker = -1;
        addscore();
        if (maxturntime > minmaxturntime)
        {
            maxturntime--;
        }
        currentState = PlayerState.MVSELECT;

        
    }
    public void loose()
    {
        Debug.Log("Du förlorade men detta är inte implementerat så jag fryser spelet här sucker");
        GameOverScreen.SetActive(true);
        //gameoverscreen och reload scene

    }
    private void addscore()
    {
        score = score + (50 * multiplier);
        timesScored++;
        if (timesScored % roundsToDoubleMultiplier == 0)
        {
            multiplier = 2 * multiplier;
        }

    }
}

