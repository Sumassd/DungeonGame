using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridState
{
    /// <summary>
    /// 被占据
    /// </summary>
    Occupied,
    /// <summary>
    /// 未被占据
    /// </summary>
    NoOccupied
}
[System.Serializable]
/// <summary>
/// 网格
/// </summary>
public class Grid
{
    public float sideLength = 1;
    public Vector2 index;//索引
    public Vector3 position;//世界坐标位置
    public GameObject prefab;//图片
    public Transform parent;
    public GridState gridState;
    public Grid(Vector2 index,Vector3 position,Transform parent)
    {
        this.index = index;
        this.position = position;
        this.parent = parent;
        Init();
    }
    public void Init()
    {
        prefab = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/FloorTe"),position,Quaternion.identity,parent);
        //prefab.GetComponent<Tile>().gridInfo = this;
    }
}
