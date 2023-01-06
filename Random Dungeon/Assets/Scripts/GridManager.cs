using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GridManager : MonoBehaviour
{
    [SerializeField]
    public Grid normalGrid;
    public Vector2 size;
    public Grid[,] grids;
    private void Awake()
    {
        grids = new Grid[(int)size.x, (int)size.y];
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Grid temp1 = new Grid(new Vector3(i * 1, j * 1), new Vector2(i, j),transform);
                grids[i, j] = temp1;
                //temp1.Index = new Vector2(i,j);
               // temp1.Pos = new Vector3(i*1,j*1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PrintGridsInfo();
        }
    }
    public void PrintGridsInfo()
    {
        foreach (var grid in grids)
        {
            Debug.Log(grid.Index);
        }
    }
}
