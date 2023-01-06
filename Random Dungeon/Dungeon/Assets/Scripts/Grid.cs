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
/// <summary>
/// 网格
/// </summary>
public class Grid
{
    public Vector2 index;//索引
    public Vector3 position;//世界坐标位置
    public GameObject prefab;//图片
    public Transform parent;
    public Grid(Vector2 index,Vector3 position,Transform parent)
    {
        this.index = index;
        this.position = position;
        this.parent = parent;
        Init();
    }
    public void Init()
    {
        GameObject r = GameObject.Instantiate(prefab,position,Quaternion.identity,parent);
    }
}
