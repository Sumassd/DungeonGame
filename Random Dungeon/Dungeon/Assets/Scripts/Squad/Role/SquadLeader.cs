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
    private void Update()
    {
        FoundMapGrid();
    }
    public void FoundMapGrid()
    {
       transform.position = MapGridManager._Ins.CurrentMousePointMapGrid.position;
    }
}
