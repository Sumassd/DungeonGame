using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SingleTileLoadState
{
    /// <summary>
    /// 装载的
    /// </summary>
    Loaded,
    /// <summary>
    /// 未装载的
    /// </summary>
    NoLoaded
}
//public enum SingleTileType
//{
//   Floor,
//   Wall,
//   Door
//}
public class SingleTile : MonoBehaviour
{
    public TileType singleTileType;//单个tile类型
    public SingleTileLoadState loadState;//是装载状态
    public SpriteRenderer tileSprite;//tile图片
    public GameObject loadedThing;//装载物
    private void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 设置单个tile状态为装载东西
    /// </summary>
    public void SetSingleTileLoadStateAsLoaded()
    {
        loadState = SingleTileLoadState.Loaded;
    }
    /// <summary>
    /// 设置单个tile状态为未装载东西
    /// </summary>
    public void SetSingleTileLoadStateAsNoLoaded()
    {
        loadState = SingleTileLoadState.NoLoaded;
        loadedThing = null;
    }
    /// <summary>
    /// 获取当前tile类型
    /// </summary>
    /// <returns></returns>
    public TileType GetCurrentSingleTileType()
    {
        return singleTileType;
    }
    /// <summary>
    /// 获取当前tile装载状态
    /// </summary>
    /// <returns></returns>
    public SingleTileLoadState GetCurrentSingleTileLoadState()
    {
        return loadState;
    }
    /// <summary>
    /// 单个tile初始化
    /// </summary>
    public void Init()
    {
        loadState = SingleTileLoadState.NoLoaded;
        loadedThing = null;
        tileSprite = transform.GetComponentInChildren<SpriteRenderer>();
    }
}
