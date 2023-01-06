using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonRoom[] rooms;
    public List<DungeonRoom> rooms2;
    public int roomCount;
    public MyTimer timer;
    public float timer1;
    public float t = 1.0f;
    public bool isGenerated;
    public List<Transform> roomParents;
    private void Awake()
    {
        rooms = new DungeonRoom[roomCount];
        timer = new MyTimer(2f);
        roomParents = new List<Transform>();
        rooms2 = new List<DungeonRoom>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timer.Go();
    }
    public void Generate()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].RoomRandomInit(i.ToString());
        }
        for (int i = 0; i < roomCount; i++)
        {
            rooms2.Add(new DungeonRoom());
        }
        for (int i = 0; i < rooms2.Count; i++)
        {
            rooms2[i].RoomRandomInit((3+i).ToString());
        }
        isGenerated = true;
    }
    private void Update()
    {
        timer.Tick();
        if (timer.IsFinish&&isGenerated==false)
        {
            Generate();
        }
    }
}
