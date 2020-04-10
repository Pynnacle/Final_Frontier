using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject roomGenerationLightEffect;

    /* <Summary>
     * The following methods are called when you choose to go in a direction that has an unexplored room (purple vortex).
     * A new room is spawned 10 units away in the respective direction.
     * If the new room doesn't have a matching exit, it will rotate 90 degrees until it does.
     */
    public GameObject GenerateRoom_North(GameObject currentRoom)
    {
        Vector3 newRoomPosition = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, currentRoom.transform.position.z + 10);
        GameObject roomGenerated = ObjectPooler.SharedInstance.GetPooledObject();
        roomGenerated.transform.position = newRoomPosition;
        roomGenerated.SetActive(true);
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
        GameObject roomGenerated = ObjectPooler.SharedInstance.GetPooledObject();
        roomGenerated.transform.position = newRoomPosition;
        roomGenerated.SetActive(true);
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
        GameObject roomGenerated = ObjectPooler.SharedInstance.GetPooledObject();
        roomGenerated.transform.position = newRoomPosition;
        roomGenerated.SetActive(true);
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
        GameObject roomGenerated = ObjectPooler.SharedInstance.GetPooledObject();
        roomGenerated.transform.position = newRoomPosition;
        roomGenerated.SetActive(true);
        Instantiate<GameObject>(roomGenerationLightEffect, newRoomPosition, Quaternion.identity);

        while (!roomGenerated.GetComponent<Room>().hasEastExit)
        {
            roomGenerated.GetComponent<Room>().RotateRoom();
            //Debug.Log("Rotate.");
        }

        return (roomGenerated);
    }

}
