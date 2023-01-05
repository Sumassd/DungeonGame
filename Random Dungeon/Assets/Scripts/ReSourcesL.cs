using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载
/// </summary>
public class ReSourcesL : MonoBehaviour
{
    public GameObject[] floors;
    public Loader F;
    public string FloorsLoaderPath = "Loaders/FloorsLoader";
    public static ReSourcesL _ins;
    private void Awake()
    {
        if (_ins!=null)
        {

        }
        else
        {
            _ins = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadAsyncRes<Loader>(FloorsLoaderPath,(rrq)=> { this.F = rrq.asset as Loader; Debug.Log("加载完成！"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject[] GetFloors()
    {
        return floors;
    }
    public static GameObject[] LoadFloors()
    {
        return Resources.LoadAll<GameObject>("Floors");
    }
    public static GameObject LoadWall_1()
    {
        return Resources.Load<GameObject>("Walls/Wall_1");
    }
    public static GameObject LoadPrefabByPath(string path)
    {
        return Resources.Load<GameObject>(path);
    }
    //IEnumerator LoadFloors()
    //{
    //    var rrq = Resources.LoadAsync<GameObject>("Floors");
    //    yield return rrq;
    //}
    public void LoadAsyncRes<T>(string path,Action<ResourceRequest> action)where T:UnityEngine.Object
    {
        StartCoroutine(LoadAsync<T>(path,action));
    }
    IEnumerator LoadAsync<T>(string path,Action<ResourceRequest> action)where T :UnityEngine.Object
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<T>(path);
        yield return resourceRequest;
        if (resourceRequest.asset!=null)
        {
            action(resourceRequest);
        }
        else
        {
            Debug.Log("加载未完成！");
        }
    }
}
