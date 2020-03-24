using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool hasNorthExit, hasEastExit, hasSouthExit, hasWestExit;
    public GameObject northRoomSensor, eastRoomSensor, southRoomSensor, westRoomSensor;
    public GameObject roomMesh;
    public GameObject unexploredRoomIndicator;

    // Start is called before the first frame update
    void Start()
    {
        //When a new room is generated, it immediately checks where adjacent unexplored rooms are and spawns an effect to indicate you can explore them.
        SpawnUnexploredRoomIndicators();
        MakeRoomVisible();
    }

    public void RotateRoom()
    {
        //The room model (separate) is rotated , not the parent, so that the raycasts will always stay the same (ie: a raycast pointing north will always point north)
        roomMesh.transform.Rotate(new Vector3(0f, 90f, 0f));

        bool hadNorthExit = hasNorthExit;
        bool hadEastExit = hasEastExit;
        bool hadSouthExit = hasSouthExit;
        bool hadWestExit = hasWestExit;

        hasNorthExit = false;
        hasEastExit = false;
        hasSouthExit = false;
        hasWestExit = false;

        if (hadNorthExit)
        {
            hasEastExit = true;
        }
        else
        {
            hasEastExit = false;
        }

        if (hadEastExit)
        {
            hasSouthExit = true;
        }
        else
        {
            hasSouthExit = false;
        }

        if (hadSouthExit)
        {
            hasWestExit = true;
        }
        else
        {
            hasWestExit = false;
        }

        if (hadWestExit)
        {
            hasNorthExit = true;
        }
        else
        {
            hasNorthExit = false;
        }

    }

    //The following methods check which directions the selected crew member can move
    //They return true if there is an exit in that direction && (there is no existing room, or existing room has matching exit (ie: north and south match))
    public bool CanGoNorth()
    {
        if (hasNorthExit){ //You can only move up if the room you're in has an exit on the north.

            northRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();

            if (northRoomSensor.GetComponent<AdjacentRoomDetector>().hit) //If there is an existing room
            {
                if (northRoomSensor.GetComponent<AdjacentRoomDetector>().ReturnAdjacentRoom().GetComponent<Room>().hasSouthExit) //Check if that existing room has a matching exit.
                {
                    return (true); //You can enter that existing room
                }
                else
                {
                    return (false); //You can't go through a wall
                }

            } else { //Else, if there is no existing adjacent room

                return (true); //You can explore a new room.
            }
            
        } else {
            return (false);
        }

    }

    public bool CanGoEast()
    {
        if (hasEastExit)
        { //You can only move right if the room you're in has an exit on the east.

            eastRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();

            if (eastRoomSensor.GetComponent<AdjacentRoomDetector>().hit) //If there is an existing room
            {
                if (eastRoomSensor.GetComponent<AdjacentRoomDetector>().ReturnAdjacentRoom().GetComponent<Room>().hasWestExit) //Check if that existing room has a matching exit.
                {
                    return (true); //You can enter that existing room
                }
                else
                {
                    return (false); //You can't go through a wall
                }

            }
            else
            { //Else, if there is no existing adjacent room

                return (true); //You can explore a new room.
            }

        }
        else
        {
            return (false);
        }
    }

    public bool CanGoSouth()
    {
        if (hasSouthExit)
        { //You can only move down if the room you're in has an exit on the south.

            southRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();

            if (southRoomSensor.GetComponent<AdjacentRoomDetector>().hit) //If there is an existing room
            {
                if (southRoomSensor.GetComponent<AdjacentRoomDetector>().ReturnAdjacentRoom().GetComponent<Room>().hasNorthExit) //Check if that existing room has a matching exit.
                {
                    return (true); //You can enter that existing room
                }
                else
                {
                    return (false); //You can't go through a wall
                }

            }
            else
            { //Else, if there is no existing adjacent room

                return (true); //You can explore a new room.
            }

        }
        else
        {
            return (false);
        }
    }

    public bool CanGoWest()
    {
        if (hasWestExit)
        { //You can only move left if the room you're in has an exit on the west.

            westRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();

            if (westRoomSensor.GetComponent<AdjacentRoomDetector>().hit) //If there is an existing room
            {
                if (westRoomSensor.GetComponent<AdjacentRoomDetector>().ReturnAdjacentRoom().GetComponent<Room>().hasEastExit) //Check if that existing room has a matching exit.
                {
                    return (true); //You can enter that existing room
                }
                else
                {
                    return (false); //You can't go through a wall
                }

            }
            else
            { //Else, if there is no existing adjacent room

                return (true); //You can explore a new room.
            }

        }
        else
        {
            return (false);
        }
    }

    void SpawnUnexploredRoomIndicators()
    {
        northRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();
        eastRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();
        southRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();
        westRoomSensor.GetComponent<AdjacentRoomDetector>().CheckForAdjacentRoom();

        //If there is an exit on the north && there is no existing room to the north, spawn an effect that indicates you can go north.
        if (hasNorthExit && !northRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            Instantiate<GameObject>(unexploredRoomIndicator, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), Quaternion.Euler(-90f, 0f, 0f));
        }

        //If there is an exit on the east && there is no existing room to the east, spawn an effect that indicates you can go east.
        if (hasEastExit && !eastRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            Instantiate<GameObject>(unexploredRoomIndicator, new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
        }

        //If there is an exit on the south && there is no existing room to the south, spawn an effect that indicates you can go south.
        if (hasSouthExit && !southRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            Instantiate<GameObject>(unexploredRoomIndicator, new Vector3(transform.position.x, transform.position.y, transform.position.z - 10), Quaternion.Euler(-90f, 0f, 0f));
        }

        //If there is an exit on the west && there is no existing room to the west, spawn an effect that indicates you can go west.
        if (hasWestExit && !westRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            Instantiate<GameObject>(unexploredRoomIndicator, new Vector3(transform.position.x - 10, transform.position.y, transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
        }

    }

    //Right now the purpose of this function is simply because I want a delay between when the light effect spawns and when the room actually shows up.
    //I could've just used a coroutine inside the room generator, but ehhhh this'll do for now.
    void MakeRoomVisible()
    {
        roomMesh.SetActive(true);
    }

}
