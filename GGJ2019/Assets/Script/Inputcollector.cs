using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollector : MonoBehaviour {

    public List<string> keylist;
    public static InputCollector Instance;
    int debugvar;
    public Player player;

    // Use this for initialization
    void Start() {
        debugvar = 0;
        keylist = new List<string>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsMVSELECT())
        {
            if (Input.GetKeyDown("up"))
            {
                keylist.Add("up");
                IconCollector.Instance.UpdateCommandList();
            }

            if (Input.GetKeyDown("down"))
            {
                keylist.Add("down");
                IconCollector.Instance.UpdateCommandList();
            }
            if (Input.GetKeyDown("left"))
            {
                keylist.Add("left");
                IconCollector.Instance.UpdateCommandList();
            }
            if (Input.GetKeyDown("right"))
            {
                keylist.Add("right");
                IconCollector.Instance.UpdateCommandList();
            }
            if (Input.GetKeyDown("space"))
            {
                keylist.Add("space");
                IconCollector.Instance.UpdateCommandList();
            }
        }
    }

    public void Emptykeylist() {
        keylist.Clear();
    }

    public List<string> Getcurrentkeylist(){
        return keylist;
    }
}
