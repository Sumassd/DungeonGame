using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DungeonTileType
{
    Floor,
    Wall,
    Door,
}

/// <summary>
/// 地牢瓦片
/// </summary>
public class DungeonTile
{
    public DungeonTileType tileType;
}
