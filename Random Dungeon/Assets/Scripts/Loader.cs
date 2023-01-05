using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
///加载器
/// </summary>
[CreateAssetMenu(fileName ="New Loader",menuName ="Creat A Loader")]
public class Loader:ScriptableObject
{
    public List<GameObject> PrefabList;
}
