using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridState
{
    Occupied,
    Normal
}
[System.Serializable]
public class Grid
{
    public Vector3 Pos;
    public GameObject prefab;
    public Vector2 Index;
    private Transform parent;
    public GridState state;
    public Grid(Vector3 Pos,Vector2 Index,Transform parent)
    {
        this.Pos = Pos;
        this.Index = Index;
        this.parent = parent;
        this.state = GridState.Normal;
        Init(Pos);
    }
    public void Init(Vector3 Pos)
    {
        prefab = GameObject.Instantiate(Resources.Load<GameObject>("Floors/floor_1"),Pos,Quaternion.identity,parent);
    }
}
