using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleBase : MonoBehaviour
{
    public float speed;
    public float attackRange;
    [SerializeField]
    public MapGrid currentMapGrid;
    public MapGrid lastMapGrid;
    public MapGrid nextMapGrid;
    public MapGrid destinationMapGrid;
    public GameObject holo;

    /// <summary>
    ///德路
    /// </summary>
    public List<MapGrid> road;
    /// <summary>
    /// 角色动作状态
    /// </summary>
    public RoleActionState actionState;
    /// <summary>
    /// 移动
    /// </summary>
    public virtual void Move()
    {
        if (road.Count <= 0)
        {
            if (transform.position == nextMapGrid.position)
            {
                actionState = RoleActionState.Idle;
            }
            return;
        }
        if (actionState == RoleActionState.Move)
        {
            nextMapGrid = road[0];
            if (transform.position == nextMapGrid.position)
            {
                road.RemoveAt(0);
                currentMapGrid = nextMapGrid;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, nextMapGrid.position, speed * Time.deltaTime);
            }
        }
    }
    public virtual void RoleBaseUpdate()
    {
        Move();
    }
}
