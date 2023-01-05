using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonRoom[] rooms;
    public int roomCount;
    private void Awake()
    {
        rooms = new DungeonRoom[roomCount];
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].RoomRandomInit(new GameObject().transform);
        }
    }
}
