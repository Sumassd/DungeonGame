using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Vector2 size;
    public Grid[,] grids;
    public Vector2 tempIndex;
    public Vector3 tempPosition;
    private void Awake()
    {
        grids = new Grid[(int)size.x, (int)size.y];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateBaseTile();
        }  
    }
    public void GenerateBaseTile()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                tempIndex.x = i;
                tempIndex.y = j;
                tempPosition.x = i * 1;
                tempPosition.y = j * 1;
                grids[i, j] = new Grid(tempIndex,tempPosition,transform);
            }
        }
    }
}
