using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {

    bool isready;
    List<string> keylist;
    int i;
    GridTile currentTile;
    GridTile targetTile;
    public Player player;

	void Start () {
		
	}
	
	void Update () {

        if (Input.GetKeyDown("enter")){

            keylist = InputCollector.Instance.Getcurrentkeylist();
            
            for (i = 0; i < keylist.Count; i++)
            {
                currentTile= player.currentTile;


                switch (keylist[i])
                {
                    case "up":
                        targetTile = currentTile.neighbourNorth;
                        if (!targetTile.isBlocking)
                        {
                            Player.Moveto(targetTile);
                        }

                        break;
                    case "down":

                        break;
                    case "left":

                        break;
                    case "right":

                        break;
                    case "space":
                        //WaitForSecondsRealtime(1) eller nått
                        break;
                    default:
                        print("skumma saker hände");
                        break;


                }
            }






        }
	}
}
