using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 房间瓦片
/// </summary>

public class RoomTile:MonoBehaviour
{
    public DungeonTileType tileType;
    public Vector2 Index;
    public DungeonRoom belongToRoom;//属于房间
}
