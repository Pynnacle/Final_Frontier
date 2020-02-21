using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicker : MonoBehaviour
{
    public GameObject[] rooms;

    /* <Summary> This method is referenced from the 'RoomOpening' script when generating a new room.
     * This method chooses a random room from an array and sends a reference back to 'RoomOpening'
     * The reason this is a separate script is because I didn't want several objects storing the same array.
     */
    public GameObject PickRoom()
    {
        GameObject newRoom = rooms[Random.Range(0, (rooms.Length) - 1)];
        return (newRoom);
    }
}
