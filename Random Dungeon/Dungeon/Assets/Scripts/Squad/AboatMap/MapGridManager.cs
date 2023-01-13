using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关于MapGrid管理器
/// </summary>
public class MapGridManager : MonoBehaviour
{
    public static MapGridManager _Ins;
    /// <summary>
    /// 当前鼠标所指MapGrid
    /// </summary>
    private MapGrid currentMousePointMapGrid;
    /// <summary>
    /// 当前鼠标所指MapGrid
    /// </summary>
    public MapGrid CurrentMousePointMapGrid { get {
            if (currentMousePointMapGrid!=null)
            {
                return currentMousePointMapGrid;
            }
            else if(lastMousePointMapGrid!=null)
            {
                return lastMousePointMapGrid;
            }
            else
            {
                return GenerateMap._Ins.FirstMapGrid();
            }
        } }
    private MapGrid lastMousePointMapGrid;
    public float maxDistance = 10.05f;

    private Vector3 nowMousePosition;
    private Vector3 lastMousePosition;
    private void Awake()
    {
        if (_Ins!=null)
        {

        }
        else
        {
            _Ins = this;
        }
    }
    private void Update()
    {
        GetMapGridByMousePosition();
    }
    /// <summary>
    /// 获取鼠标所指MapGrid
    /// </summary>
    /// <returns></returns>
    private MapGrid GetMapGridByMousePosition()
    {
        nowMousePosition = RaycastTool.GetMousePositionTransitateWorldSpace();
        if (nowMousePosition==lastMousePosition)//鼠标移动时进行寻找MapGrid，不移动不寻找MapGrid
        {

        }
        else
        {
            currentMousePointMapGrid = GenerateMap._Ins.GetNearMapGridByPosition(RaycastTool.GetMousePositionTransitateWorldSpace(), maxDistance);
            lastMousePosition = nowMousePosition;
            if (currentMousePointMapGrid!=null)
            {
                lastMousePointMapGrid = currentMousePointMapGrid;
            }
        }
        return currentMousePointMapGrid;
        //GenerateMap._Ins.GetNearMapGridByPosition(RaycastTool.GetMousePositionTransitateWorldSpace(),maxDistance);
    } 
}
