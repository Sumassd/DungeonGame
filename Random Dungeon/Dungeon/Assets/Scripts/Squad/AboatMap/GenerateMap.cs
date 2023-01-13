using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 产生地图
/// </summary>

public class GenerateMap : MonoBehaviour
{
    public static GenerateMap _Ins;
    public Vector2 size;
    public GameObject Block;
    public List<MapBlock> mapBlocks;
    public MapGrid[,] mapGrids;

    private Vector3 positionForRGC;
    private Vector2 indexForRGC;
    private int tempSortingLayerCount;
    private void Awake()
    {
        if (_Ins!=null)
        {

        }
        else
        {
            _Ins = this;
        }
        mapBlocks = new List<MapBlock>();
        //mapGrids = new MapGrid[(int)size.x, (int)size.y];
    }
    private void Start()
    {
        mapGrids = new MapGrid[(int)size.x, (int)size.y];
        Generate();
        Debug.Log(mapGrids.Length);
    }
    public void Generate()
    {
        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j < size.x; j++)
            {
                positionForRGC = new Vector3(j - i, 0.5f * (i + j));
                indexForRGC = new Vector2(j, i);
                MapBlock prefab = GameObject.Instantiate(Block, positionForRGC, Quaternion.identity, transform).GetComponent<MapBlock>();
                if (prefab != null)
                {
                    prefab.sprite.sortingOrder = tempSortingLayerCount;
                    tempSortingLayerCount--;
                }

                if (prefab.GetComponent<MapBlock>() != null)
                {
                    prefab.GetComponent<MapBlock>().myGrid.index = indexForRGC;
                    prefab.GetComponent<MapBlock>().myGrid.position = positionForRGC;
                    mapBlocks.Add(prefab.GetComponent<MapBlock>());
                }
                mapGrids[j, i] = prefab.myGrid;
            }
        }
    }
    /// <summary>
    /// 获取离指定位置最近的MapGrid
    /// </summary>
    /// <param name="position"></param>
    /// <param name="maxDistance">最大距离，allMapGrids与指定位置的距离超过此数值则返回null</param>
    /// <returns></returns>
    public MapGrid GetNearMapGridByPosition(Vector3 position,float maxDistance)
    {
        MapGrid result=null;
        float distance=9999f;
        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j < size.x; j++)
            {
                if (Vector3.Distance(mapGrids[j,i].position,position)<distance)
                {
                    distance = Vector3.Distance(mapGrids[j,i].position,position);
                    result = mapGrids[j, i];
                }
            }
        }
        if (distance>maxDistance)
        {
            result = null;
        }
        //Debug.Log(distance);
        //Debug.Log(result.position);
        return result;
    }
    /// <summary>
    /// 返回索引为(0,0)的MapGrid
    /// </summary>
    /// <returns></returns>
    public MapGrid FirstMapGrid()
    {
        return mapGrids[0, 0];
    }
    /// <summary>
    /// 获取指定索引的MapGrid,未找到返回(0,0)的MapGrid;
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public MapGrid GetPointMapGrid(int x,int y)
    {
        if (mapGrids[x,y]!=null)
        {
            return mapGrids[x, y];
        }
        else
        {
            return mapGrids[0, 0];
        }
    }
}
