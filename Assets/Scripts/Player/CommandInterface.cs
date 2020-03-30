using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandInterface : MonoBehaviour
{
    public GameObject selectedCrewMember; //This will be whichever crew member you last clicked on.

    //References to each directional button.
    public GameObject moveUpButton, moveRightButton, moveDownButton, moveLeftButton; 
    public Text movesRemainingDisplay;

    //References to each UI component of the crew member profile display.
    public Text crewMemberName_txt, crewMemberPower_txt, crewMemberAgility_txt, crewMemberIntellect_txt, crewMemberEndurance_txt;
    public Image crewMemberPortrait_img;

    public GameObject roomGenerator; //Reference to the game object that handles room generation.
    public float moveDelayAfterGeneratingNewRoom; //How long the character waits before moving to an unexplored room.
    public bool destinationReached; //Disables the command interface while a crew member is moving to a new room.

    GameObject newRoom; //Reference to the last room that was generated.


    /* <Summary>
     * Called after a crew member is clicked on.
     * Only directions that it is possible to go in will appear in the command interface.
     */
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

        movesRemainingDisplay.text = selectedCrewMember.GetComponent<CrewMember>().movesRemaining.ToString();
    }


    /* <Summary>
     * Also called after a crew member is clicked on.
     * Updates the profile that is displayed in the top left corner.
     */
    public void UpdateCrewMemberProfile()
    {
        crewMemberName_txt.text = selectedCrewMember.GetComponent<CrewMember>().name;
        crewMemberPower_txt.text = "Pow: " + selectedCrewMember.GetComponent<CrewMember>().power.ToString();
        crewMemberAgility_txt.text = "Ag: " + selectedCrewMember.GetComponent<CrewMember>().agility.ToString();
        crewMemberIntellect_txt.text = "Int: " + selectedCrewMember.GetComponent<CrewMember>().intellect.ToString();
        crewMemberEndurance_txt.text = "End: " + selectedCrewMember.GetComponent<CrewMember>().endurance.ToString();
        crewMemberPortrait_img.sprite = selectedCrewMember.GetComponent<CrewMember>().portrait;
    }

    //Fires when the move up button is clicked.
    public void GoNorth()
    {
        if (!selectedCrewMember.GetComponent<CrewMember>().turnIsOver)
        {
            //If there is an existing room to the north...
            if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().northRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
            {
                //Tell the selected crew member to move to that room.
                selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().northRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom, false);
            }
            else //If there is only an exit to the north, but no room exists there yet...
            {
                //Generate a new room...
                newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_North(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
                //The crew member 'waits' a little before moving to the new room.
                Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
            }
        }
    }

    public void GoEast()
    {
        if (!selectedCrewMember.GetComponent<CrewMember>().turnIsOver)
        {
            //If there is an existing room to the east...
            if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().eastRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
            {
                //Tell the selected crew member to move to that room.
                selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().eastRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom, false);
            }
            else //If there is only an exit to the east, but no room exists there yet...
            {
                //Generate a new room...
                newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_East(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
                //The crew member 'waits' a little before moving to the new room.
                Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
            }
        }
    }

    public void GoSouth()
    {
        if (!selectedCrewMember.GetComponent<CrewMember>().turnIsOver)
        {
            //If there is an existing room to the south...
            if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().southRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
            {
                //Tell the selected crew member to move to that room.
                selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().southRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom, false);
            }
            else //If there is only an exit to the south, but no room exists there yet...
            {
                //Generate a new room...
                newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_South(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
                //The crew member 'waits' a little before moving to the new room.
                Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
            }
        }
    }

    public void GoWest()
    {
        if (!selectedCrewMember.GetComponent<CrewMember>().turnIsOver)
        {
            //If there is an existing room to the west...
            if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().westRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
            {
                //Tell the selected crew member to move to that room.
                selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().westRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom, false);
            }
            else //If there is only an exit to the west, but no room exists there yet...
            {
                //Generate a new room...
                newRoom = roomGenerator.GetComponent<RoomGenerator>().GenerateRoom_West(selectedCrewMember.GetComponent<CrewMember>().currentLocation);
                //The crew member 'waits' a little before moving to the new room.
                Invoke("MoveCrewMember", moveDelayAfterGeneratingNewRoom);
            }
        }
    }

    void MoveCrewMember()
    {
        selectedCrewMember.GetComponent<CrewMember>().Move(newRoom, true);
    }

    public void TurnEnded()
    {
        selectedCrewMember = null;
        gameObject.SetActive(false);
    }
}
