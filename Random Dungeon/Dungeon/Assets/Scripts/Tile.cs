using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Floor,Wall,Door
}
//public enum OccupiedState
//{
//    Occupied,
//    NoOccupied
//}

public class Tile : MonoBehaviour
{
    public List<SingleTile> singleTileList;
    public TileType currentTileType;
    //public OccupiedState occupiedState;
    public Grid gridInfo;
    private void Awake()
    {
        GetChildren();
        SetTileType(TileType.Floor);
    }
    /// <summary>
    /// 获取子对象上的SingleTile
    /// </summary>
    private void GetChildren()
    {
        singleTileList = new List<SingleTile>();
        for (int i = 0; i < transform.childCount; i++)
        {
            singleTileList.Add(transform.GetChild(i).GetComponent<SingleTile>());
        }
    }
    /// <summary>
    /// 设置Tile类型
    /// </summary>
    /// <param name="type"></param>
    public void SetTileType(TileType type)
    {
        switch (type)
        {
            case TileType.Floor:
                currentTileType = TileType.Floor;
                gridInfo.gridState = GridState.NoOccupied;
                SetSingleSelf(0);
                break;
            case TileType.Wall:
                currentTileType = TileType.Wall;
                gridInfo.gridState = GridState.Occupied;
                SetSingleSelf(1);
                break;
            case TileType.Door:
                currentTileType = TileType.Door;
                gridInfo.gridState = GridState.Occupied;
                SetSingleSelf(2);
                break;
            default:
                break;
        }
        ChangeTile(type);
    }
    /// <summary>
    /// 改变Tile
    /// </summary>
    /// <param name="type"></param>
    private void ChangeTile(TileType type)
    {
        for (int i = 0; i < singleTileList.Count; i++)
        {
            if (singleTileList[i].singleTileType== type)
            {
                singleTileList[i].gameObject.SetActive(true);
            }
            else
            {
                singleTileList[i].gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// 获取当前Tile类型
    /// </summary>
    /// <returns></returns>
    public TileType GetCurrentTileType()
    {
        return currentTileType;
    }
    /// <summary>
    /// 仅设置一个子物体开启
    /// </summary>
    /// <param name="index"></param>
    public void SetSingleSelf(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == index)
            {
                singleTileList[i].gameObject.SetActive(true);
            }
            else
            {
                singleTileList[i].gameObject.SetActive(false);
            }
        }
    }
}
