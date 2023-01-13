using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 小队队长
/// </summary>
public class SquadLeader : RoleBase
{
    [SerializeField]
    public MapGrid currentMapGrid;
    public MapGrid lastMapGrid;
    public MapGrid destinationMapGrid;
    public Vector2 dMGIndex;
    public GameObject holo;

    public List<MapGrid> road;
    private void Start()
    {
        currentMapGrid = GenerateMap._Ins.GetPointMapGrid(0,0);
        destinationMapGrid = GenerateMap._Ins.GetPointMapGrid(4,2);
        transform.position = currentMapGrid.position;
        //GoToDestination();
    }
    private void Update()
    {
        ////FoundMapGrid();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToDestination();
            foreach (var roadMapGrid in road)
            {
                GameObject.Instantiate(holo,roadMapGrid.position,Quaternion.identity);
            }
        }
    }
    public void FoundMapGrid()
    {
       currentMapGrid = MapGridManager._Ins.CurrentMousePointMapGrid;
    }
    public void GoToDestination()
    {
        //AStarRoad.SeekRoad(currentMapGrid,destinationMapGrid,GenerateMap._Ins.mapGrids,ref road);
        AStarRoad.SecondSeekRoad(currentMapGrid, destinationMapGrid, GenerateMap._Ins.mapGrids, ref road);
    }
}
