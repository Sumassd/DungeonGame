using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AStar
/// </summary>
public class AStarRoad
{
    //public List<MapGrid> roadList;
    //public Vector2[] directionVec;
    ///// <summary>
    ///// 寻路,返回路径列表
    ///// </summary>
    ///// <param name="startMapGrid"></param>
    ///// <param name="endMapGrid"></param>
    ///// <param name="map"></param>
    ///// <param name="roadList"></param>
    //public static void SeekRoad(MapGrid startMapGrid, MapGrid endMapGrid, MapGrid[,] map, ref List<MapGrid> roadList)
    //{
    //    Vector2[] directionVec = new Vector2[] { new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1) };
    //    if (startMapGrid==endMapGrid)
    //    {
    //        return;
    //    }
    //    float dis = 9999f;
    //    for (int i = 0; i < directionVec.Length; i++)
    //    {
    //        if (((int)startMapGrid.index.x + (int)directionVec[i].x)<0||((int)startMapGrid.index.y + (int)directionVec[i].y)<0||map.GetLength(1)< ((int)startMapGrid.index.x + (int)directionVec[i].x)||map.GetUpperBound(0)+1< ((int)startMapGrid.index.y + (int)directionVec[i].y))
    //        {

    //        }
    //        else {
    //            MapGrid temp = map[(int)startMapGrid.index.x + (int)directionVec[i].x, (int)startMapGrid.index.y + (int)directionVec[i].y];
    //            if (temp != null)
    //            {
    //                if (Vector3.Distance(temp.position, endMapGrid.position) <= dis)
    //                {
    //                    dis = Vector3.Distance(temp.position, endMapGrid.position);
    //                    startMapGrid = temp;
    //                }
    //            }
    //        }
    //    }
    //    Debug.Log(startMapGrid.index);
    //    Debug.Log("SeekL");
    //    roadList.Add(startMapGrid);
    //    SeekRoad(startMapGrid,endMapGrid,map,ref roadList);
    //}
    /// <summary>
    /// 寻路
    /// </summary>
    /// <param name="startMapGrid"></param>
    /// <param name="endMapGrid"></param>
    /// <param name="map"></param>
    /// <param name="roadList"></param>
    public static void SecondSeekRoad(MapGrid startMapGrid, MapGrid endMapGrid, MapGrid[,] map, ref List<MapGrid> roadList)
    {
        MapGrid result = null;
        Vector2[] directionVec = new Vector2[] { new Vector2(1, 0), new Vector2(0,1), new Vector2(-1, 0), new Vector2(0, -1) };
        if (startMapGrid == endMapGrid)
        {
            return;
        }
        float dis = 9999f;
        for (int i = 0; i < directionVec.Length; i++)
        {
            if (((int)startMapGrid.index.x + (int)directionVec[i].x) < 0 || ((int)startMapGrid.index.y + (int)directionVec[i].y) < 0 || map.GetLength(0) < ((int)startMapGrid.index.x + (int)directionVec[i].x) || map.Length/map.GetLength(0) < ((int)startMapGrid.index.y + (int)directionVec[i].y))
            {

            }
            else
            {
                MapGrid temp = map[(int)startMapGrid.index.x + (int)directionVec[i].x, (int)startMapGrid.index.y + (int)directionVec[i].y];
                if (temp != null)
                {
                    Debug.Log(temp.index);
                    if (GetTwoLocationDistance(temp.index, endMapGrid.index) < dis)
                    {
                        dis = GetTwoLocationDistance(temp.index, endMapGrid.index);
                        result = temp;///
                        Debug.Log(dis);
                        //Debug.Log(startMapGrid.index);
                    }
                }
            }
        }
       // Debug.Log(startMapGrid.index);
        //Debug.Log("SeekL");
        roadList.Add(result);
        startMapGrid = result;
        SecondSeekRoad(startMapGrid, endMapGrid, map, ref roadList);
    }
    public static float GetTwoLocationDistance(Vector2 A,Vector2 B)
    {
        float result =(A-B).magnitude;
        return result;
    }
}
