using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField] private GameObject tilePrefab;

    [Header("Level Size")]
    [Range(1, 20)] [SerializeField] private int xSize = 1;
    [Range(1, 20)] [SerializeField] private int ySize = 1;

}
