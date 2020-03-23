using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandInterface : MonoBehaviour
{
    public GameObject moveUpButton, moveRightButton, moveDownButton, moveLeftButton;
    public GameObject selectedCrewMember;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void GoNorth()
    {
        if (selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().northRoomSensor.GetComponent<AdjacentRoomDetector>().hit)
        {
            selectedCrewMember.GetComponent<CrewMember>().Move(selectedCrewMember.GetComponent<CrewMember>().currentLocation.GetComponent<Room>().northRoomSensor.GetComponent<AdjacentRoomDetector>().adjacentRoom);
        }
        else
        {
            //I'll create a new script that handles spawning rooms...
            //A little delay...
            //Then move.
        }
    }
}
