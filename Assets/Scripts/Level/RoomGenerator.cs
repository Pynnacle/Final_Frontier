using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject roomGenerationLightEffect;

    public GameObject GenerateRoom_North(GameObject currentRoom)
    {
        Vector3 newRoomPosition = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, currentRoom.transform.position.z + 10);
        GameObject roomGenerated = Instantiate<GameObject>(rooms[Random.Range(0, (rooms.Length) - 1)], newRoomPosition, Quaternion.identity);
        Instantiate<GameObject>(roomGenerationLightEffect, newRoomPosition, Quaternion.identity);

        while (!roomGenerated.GetComponent<Room>().hasSouthExit)
        {
            roomGenerated.GetComponent<Room>().RotateRoom();
            //Debug.Log("Rotate.");
        }
        
        return (roomGenerated);
    }

    public GameObject GenerateRoom_East(GameObject currentRoom)
    {
        Vector3 newRoomPosition = new Vector3(currentRoom.transform.position.x + 10, currentRoom.transform.position.y, currentRoom.transform.position.z);
        GameObject roomGenerated = Instantiate<GameObject>(rooms[Random.Range(0, (rooms.Length) - 1)], newRoomPosition, Quaternion.identity);
        Instantiate<GameObject>(roomGenerationLightEffect, newRoomPosition, Quaternion.identity);

        while (!roomGenerated.GetComponent<Room>().hasWestExit)
        {
            roomGenerated.GetComponent<Room>().RotateRoom();
            //Debug.Log("Rotate.");
        }

        return (roomGenerated);
    }

    public GameObject GenerateRoom_South(GameObject currentRoom)
    {
        Vector3 newRoomPosition = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, currentRoom.transform.position.z - 10);
        GameObject roomGenerated = Instantiate<GameObject>(rooms[Random.Range(0, (rooms.Length) - 1)], newRoomPosition, Quaternion.identity);
        Instantiate<GameObject>(roomGenerationLightEffect, newRoomPosition, Quaternion.identity);

        while (!roomGenerated.GetComponent<Room>().hasNorthExit)
        {
            roomGenerated.GetComponent<Room>().RotateRoom();
            //Debug.Log("Rotate.");
        }

        return (roomGenerated);
    }

    public GameObject GenerateRoom_West(GameObject currentRoom)
    {
        Vector3 newRoomPosition = new Vector3(currentRoom.transform.position.x - 10, currentRoom.transform.position.y, currentRoom.transform.position.z);
        GameObject roomGenerated = Instantiate<GameObject>(rooms[Random.Range(0, (rooms.Length) - 1)], newRoomPosition, Quaternion.identity);
        Instantiate<GameObject>(roomGenerationLightEffect, newRoomPosition, Quaternion.identity);

        while (!roomGenerated.GetComponent<Room>().hasEastExit)
        {
            roomGenerated.GetComponent<Room>().RotateRoom();
            //Debug.Log("Rotate.");
        }

        return (roomGenerated);
    }

}
