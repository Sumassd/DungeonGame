using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RoleActionState 
{
    Idle,DoAction,Move,Attack,Throw,Death,Hit
}

/// <summary>
/// 小队队长
/// </summary>
public class SquadLeader : RoleBase
{
    public MyTimer jumpToNextTimer;
    private void Awake()
    {
        jumpToNextTimer = new MyTimer(1f);
    }
    private void Start()
    {
        currentMapGrid = GenerateMap._Ins.GetPointMapGrid(0,0);
        destinationMapGrid = GenerateMap._Ins.GetPointMapGrid(4,2);
        GetCurrentMapGrid();
        transform.position = currentMapGrid.position;
        //nextMapGrid = currentMapGrid;
        //GoToDestination();
    }
    private void Update()
    {
        //jumpToNextTimer.Tick();
        ////FoundMapGrid();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetRoadList();
            foreach (var roadMapGrid in road)
            {
                GameObject.Instantiate(holo,roadMapGrid.position,Quaternion.identity);
            }
            actionState = RoleActionState.Move;
        }
        RoleBaseUpdate();
    }
    /// <summary>
    /// 获取当前CurrentMapGrid
    /// </summary>
    public MapGrid GetCurrentMapGrid()
    {
        return currentMapGrid = GenerateMap._Ins.GetNearMapGridByPosition(transform.position,10.05f);
    }
    public void FoundMapGrid()
    {
       currentMapGrid = MapGridManager._Ins.CurrentMousePointMapGrid;
    }
    /// <summary>
    /// 获得路径列表
    /// </summary>
    public void GetRoadList()
    {
        road = new List<MapGrid>();//每次定位目标清空之前的路
        //AStarRoad.SeekRoad(currentMapGrid,destinationMapGrid,GenerateMap._Ins.mapGrids,ref road);
        AStarRoad.SecondSeekRoad(currentMapGrid, destinationMapGrid, GenerateMap._Ins.mapGrids, ref road);

    }
}
