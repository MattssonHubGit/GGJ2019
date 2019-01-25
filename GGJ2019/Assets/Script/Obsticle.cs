using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obsticle : MonoBehaviour {

    public GridTile myTile;
    public bool blocks = true;

    public abstract void OnEnter();
    public abstract void OnAttemptEnter();
    public abstract void OnExit();
    public abstract void OnAttemptExit();
}
