using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicker : MonoBehaviour
{
    public GameObject[] rooms;

    public GameObject PickRoom()
    {
        GameObject newRoom = rooms[Random.Range(0, (rooms.Length) - 1)];
        return (newRoom);
    }
}
