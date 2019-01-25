using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField] private GridTile tilePrefab;
    private GridTile[,] level;

    [Header("Level Size")]
    [Range(1, 20)] [SerializeField] private int xSize = 1;
    [Range(1, 20)] [SerializeField] private int ySize = 1;
    [Range(0, 5)] [SerializeField] private float xOffset = 2f;
    [Range(0, 5)] [SerializeField] private float yOffset = 2f;

    private void Start()
    {
        
    }

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GenerateLevel();
        }
    }

    [ContextMenu("New Level")]
    private void GenerateLevel()
    {

        //Generate new Level
        level = new GridTile[xSize, ySize];
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GridTile _tile = Instantiate(tilePrefab, new Vector3(0 + x * xOffset, 0, 0 + y * yOffset), Quaternion.identity, this.transform);
                _tile.gameObject.name = "Tile: " + x + ", " + y;
                level[x, y] = _tile;
            }
        }

        //Set up neighbours
        for (int x = 0; x < level.GetLength(0); x++)
        {
            for (int y = 0; y < level.GetLength(1); y++)
            {
                //north
                if (y < level.GetLength(1) - 1)
                {
                    level[x, y].neighbourNorth = level[x, y + 1];
                    level[x, y].neighbours.Add(level[x, y + 1]);
                }

                //south
                if (y > 0)
                {
                    level[x, y].neighbourSouth = level[x, y - 1];
                    level[x, y].neighbours.Add(level[x, y - 1]);
                }

                //east
                if (x < level.GetLength(0) - 1)
                {
                    level[x, y].neighbourEast = level[x + 1, y];
                    level[x, y].neighbours.Add(level[x + 1, y]);
                }

                //west
                if (x > 0)
                {
                    level[x, y].neighbourWest = level[x -1, y];
                    level[x, y].neighbours.Add(level[x - 1, y]);
                }

            }
        }
    }
}
