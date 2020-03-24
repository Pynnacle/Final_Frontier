using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandInterface : MonoBehaviour
{
    public GameObject moveUpButton, moveRightButton, moveDownButton, moveLeftButton;
    public GameObject selectedCrewMember;
    public GameObject roomGenerator;
    public float moveDelayAfterGeneratingNewRoom;
    public bool destinationReached; //Disables the command interface while a crew member is moving to a new room.

    GameObject newRoom; //Reference to the last room that was generated.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Only directions that it is possible to go in will appear in the command interface.
    public void UpdateDirectionsCrewMemberCanTravel(bool north, bool east, bool south, bool west)
    {
        if (north) {
            moveUpButton.SetActive(true);
        } else {
            moveUpButton.SetActive(false);
        }

        if (east) {
            moveRightButton.SetActive(true);
        } else {
            moveRightButton.SetActive(false);
        }

        if (south) {
            moveDownButton.SetActive(true);
        } else {
            moveDownButton.SetActive(false);
        }

        if (west) {
            moveLeftButton.SetActive(true);
        } else {
            moveLeftButton.SetActive(false);
        }
    }

    //Fires when the move up button is clicked.
    public void GoNorth()
    {
        //If there is an existing room to the north...
        if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().northRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            //Tell the selected crew member to move to that room.
            selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().northRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom);
        }
        else //If there is only an exit to the north, but no room exists there yet...
        {
            //Generate a new room...
            newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_North(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
            //The crew member 'waits' a little before moving to the new room.
            Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
        }
    }

    public void GoEast()
    {
        //If there is an existing room to the east...
        if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().eastRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            //Tell the selected crew member to move to that room.
            selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().eastRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom);
        }
        else //If there is only an exit to the east, but no room exists there yet...
        {
            //Generate a new room...
            newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_East(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
            //The crew member 'waits' a little before moving to the new room.
            Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
        }
    }

    public void GoSouth()
    {
        //If there is an existing room to the south...
        if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().southRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            //Tell the selected crew member to move to that room.
            selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().southRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom);
        }
        else //If there is only an exit to the south, but no room exists there yet...
        {
            //Generate a new room...
            newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_South(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
            //The crew member 'waits' a little before moving to the new room.
            Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
        }
    }

    public void GoWest()
    {
        //If there is an existing room to the west...
        if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().westRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            //Tell the selected crew member to move to that room.
            selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().westRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom);
        }
        else //If there is only an exit to the west, but no room exists there yet...
        {
            //Generate a new room...
            newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_West(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
            //The crew member 'waits' a little before moving to the new room.
            Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
        }
    }

    void MoveCrewMember()
    {
        selectedCrewMember.GetComponent<CrewMember>().Move(newRoom);
    }
}
