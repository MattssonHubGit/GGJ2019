using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    [SerializeField] private List<Transform> path;
    [SerializeField] private float moveSpeed = 4f;
    private int pathCounter = 0;
    

    private void Update()
    {
        MoveController();
    }

    private void MoveController()
    {
        if (Vector3.Distance(transform.position, path[pathCounter].position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[pathCounter].position, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (pathCounter == path.Count - 1)
            {
                pathCounter = 0;
            }
            else
            {
                pathCounter++;
            }
        }

    }

    /*IEnumerator Move(GridTile targetTile)
    {
        while (Vector3.Distance(transform.position, targetTile.pointToStand.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTile.pointToStand.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

    }*/
}

