using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 射线检测工具类
/// </summary>
public class RaycastTool : MonoBehaviour
{
    /// <summary>
    /// 获取鼠标在世界空间下的位置
    /// </summary>
    /// <returns></returns>
    public static Vector3 GetMousePositionTransitateWorldSpace()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
