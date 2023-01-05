using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// RoomGenerator
/// </summary>
public class DungeonRoom
{
    public Transform parent;
    /// <summary>
    /// 起始位置
    /// </summary>
    public Vector3 startPos;
    public Vector2 size;
    public GameObject floor;
    public GameObject bottomWall;
    public GameObject wall;
    public GameObject topWall;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject door;
    public float distance = 1.0f;
    [SerializeField]
    public Grid[,] grids;
    // Start is called before the first frame update
    /// <summary>
    /// 生成地板
    /// </summary>
    public void GenerateFloor(Vector3 starPos)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject result= GameObject.Instantiate(floor,startPos+new Vector3(i*distance,j*distance,0),Quaternion.identity);
                result.GetComponent<RoomTile>().belongToRoom = this;
                result.GetComponent<RoomTile>().Index = new Vector2(i,j);
                result.transform.SetParent(parent);
                grids[i, j] = new Grid();
                grids[i, j].Pos = startPos+ new Vector3(i * distance, j * distance, 0);
                grids[i, j].prefab = result;
            }
        }

    }
    public void GenerateWall(Vector3 startPos)
    {
        for (int i = 0; i < size.x; i++)
        {
            GameObject bw= GameObject.Instantiate(bottomWall,startPos+new Vector3(i*distance,0,0),Quaternion.identity);
            bw.GetComponent<RoomTile>().belongToRoom = this;
            bw.GetComponent<RoomTile>().Index = new Vector2(i,0);
            bw.transform.SetParent(parent);
        }
        for (int i = 0; i <size.x; i++)
        {
            GameObject tw = GameObject.Instantiate(topWall, startPos + new Vector3(i * distance, size.y*distance, 0), Quaternion.identity);
            tw.GetComponent<RoomTile>().belongToRoom = this;
            tw.GetComponent<RoomTile>().Index = new Vector2(i, size.y);
            tw.transform.SetParent(parent);
        }
        for (int i = 0; i < size.x; i++)
        {
            GameObject w = GameObject.Instantiate(wall, startPos + new Vector3(i * distance, size.y-1 * distance, 0), Quaternion.identity);
            w.GetComponent<RoomTile>().belongToRoom = this;
            w.GetComponent<RoomTile>().Index = new Vector2(i, size.y-1);
            w.transform.SetParent(parent);
        }
        for (int i = 0; i < size.y; i++)
        {
            GameObject lw = GameObject.Instantiate(leftWall, startPos + new Vector3(-1, i* distance, 0), Quaternion.identity);
            lw.GetComponent<RoomTile>().belongToRoom = this;
            lw.GetComponent<RoomTile>().Index = new Vector2(0, i);
            lw.transform.SetParent(parent);
        }
        for (int i = 0; i < size.y; i++)
        {
            GameObject rw = GameObject.Instantiate(rightWall, startPos + new Vector3(size.x * distance, i * distance, 0), Quaternion.identity);
            rw.GetComponent<RoomTile>().belongToRoom = this;
            rw.GetComponent<RoomTile>().Index = new Vector2(size.y-1, i);
            rw.transform.SetParent(parent);
        }
    }
    public void RoomInit(int width,int length,Transform parent)
    {
        size.x = width;
        size.y = length;
        this.parent = parent;
        grids = new Grid[(int)size.x, (int)size.y];
        floor = ReSourcesL.LoadPrefabByPath("Floors/floor_1");
        wall = ReSourcesL.LoadPrefabByPath("Walls/wall_1");
        topWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top");
        bottomWall = ReSourcesL.LoadPrefabByPath("Walls/wall_bottom");
        leftWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top_left");
        rightWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top_right");
        if (parent!=null)
        {
            GenerateFloor(parent.transform.position);
            GenerateWall(parent.transform.position);
        }
    }
    public void RoomRandomInit(Transform parent)
    {
        size.x = (int)Random.Range(5,10);
        size.y = (int)Random.Range(5,10);
        this.parent = parent;
        grids = new Grid[(int)size.x, (int)size.y];
        Load();
        //floor = ReSourcesL.LoadPrefabByPath("Floors/floor_1");
        //wall = ReSourcesL.LoadPrefabByPath("Walls/wall_1");
        //topWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top");
        //bottomWall = ReSourcesL.LoadPrefabByPath("Walls/wall_bottom");
        //leftWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top_left");
        //rightWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top_right");
        if (parent != null)
        {
            GenerateFloor(parent.transform.position);
            GenerateWall(parent.transform.position);
        }
    }
    async public void Load()
    {
        floor = ReSourcesL.LoadPrefabByPath("Floors/floor_1");
        wall = ReSourcesL.LoadPrefabByPath("Walls/wall_1");
        topWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top");
        bottomWall = ReSourcesL.LoadPrefabByPath("Walls/wall_bottom");
        leftWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top_left");
        rightWall = ReSourcesL.LoadPrefabByPath("Walls/wall_top_right");
    }
}
