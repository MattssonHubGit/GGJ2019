using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GridTile currentTile = null;
    Transform targetPos;
    public GridTile targetTile;
    List<string> keylist;
    int i;

    public enum PlayerState { WAITING, EXECUTING, OTHER};
    private PlayerState currentState = PlayerState.OTHER;

    public void Moveto(GridTile targetTile)
    {
        
    
    }
    void Update()
    {

        switch (currentState)
        {
            case PlayerState.WAITING:

                break;
            case PlayerState.EXECUTING:
                CommandController();
                break;
            case PlayerState.OTHER:

                break;
            default:
                break;
        }

        /*if (Input.GetKeyDown("enter"))
        {

            keylist = InputCollector.Instance.Getcurrentkeylist();

            for (i = 0; i < keylist.Count; i++)
            {

                //här måste jag ta reda på vilken tile som är currentTile

                switch (keylist[i])
                {
                    case "up":
                        targetTile = currentTile.neighbourNorth;
                        if (!targetTile.isBlocking)
                        {
                            StartCoroutine(Move(targetTile));  
                        }

                        break;
                    case "down":

                        break;
                    case "left":

                        break;
                    case "right":

                        break;
                    case "space":

                        break;
                    default:
                        print("skumma saker hände");
                        break;


                }
            }
        }*/
    }
    IEnumerator Move(GridTile targetTile)
    {
        while (Vector3.Distance(transform.position, targetTile.transform.position) > 0.01)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, Time.deltaTime);

            yield return null;
        }

        currentState = PlayerState.EXECUTING;
    }

    private void CommandController() {
        if (Input.GetKeyDown("enter"))
        {

            keylist = InputCollector.Instance.Getcurrentkeylist();

            for (i = 0; i < keylist.Count; i++)
            {

                //här måste jag ta reda på vilken tile som är currentTile

                switch (keylist[i])
                {
                    case "up":
                        targetTile = currentTile.neighbourNorth;
                        if (!targetTile.isBlocking)
                        {
                            currentState = PlayerState.WAITING;
                            StartCoroutine(Move(targetTile));
                        }

                        break;
                    case "down":

                        break;
                    case "left":

                        break;
                    case "right":

                        break;
                    case "space":

                        break;
                    default:
                        print("skumma saker hände");
                        break;


                }
            }
        }
    }
}
