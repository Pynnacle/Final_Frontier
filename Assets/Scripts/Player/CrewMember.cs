using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    POWER, AGILITY, INTELLECT, ENDURANCE
}

public class CrewMember : MonoBehaviour
{
    public new string name;
    public Sprite portrait;

    //Statistics
    public int power;
    public int agility;
    public int intellect;
    public int endurance;

    //Movement
    public float moveDuration;
    public int movesRemaining;
    float startTime = 0f, timeElapsed;
    Vector3 startPosition, endPosition;
    bool isMoving;
    bool triggerRoomEvent;

    //References
    public GameObject currentLocation; //Reference to the room crew member is in.
    public GameObject commandInterface; //Reference to the command interface.
    public RoomEventHandler roomEventHandler; //Reference to the room event handler.

    public bool canGoNorth, canGoEast, canGoSouth, canGoWest;
    public bool turnIsOver;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float percent = (Time.time - startTime) / moveDuration;
            if (percent >= 1)
            { //Percent of lerp
                transform.position = endPosition;
                isMoving = false;
                UpdateCommandInterface();

                if (triggerRoomEvent)
                {
                    roomEventHandler.TriggerRoomEvent(gameObject);
                    triggerRoomEvent = false;
                    turnIsOver = true;
                }
                else
                {
                    movesRemaining--;
                    if(movesRemaining <= 0)
                    {
                        turnIsOver = true;
                    }
                }
                return;
            }

            transform.position = Vector3.Lerp(startPosition, endPosition, percent);
        }
    }


    /* <Summary>
     * Called when a direction on the command interface is clicked.
     * Causes the code in the this^update loop to run.
     */
    public void Move(GameObject targetRoom, bool isNewRoom)
    {
        isMoving = true;
        startTime = Time.time;
        startPosition = transform.position;
        endPosition = new Vector3(targetRoom.transform.position.x, transform.position.y, targetRoom.transform.position.z);
        currentLocation = targetRoom;
        triggerRoomEvent = isNewRoom;
    }

    void OnMouseDown()
    {
        if (!turnIsOver) {
            Debug.Log(name + " was selected.");
            commandInterface.SetActive(true);
            UpdateCommandInterface();
        }
    }

    /* <Summary>
     * Called when this crew member is clicked on.
     * Another script (Room) determines which directions it is possible to go, then this function passes that info to the command interface.
     */
    void UpdateCommandInterface()
    {
        commandInterface.GetComponent<CommandInterface>().selectedCrewMember = gameObject;
        canGoNorth = currentLocation.GetComponent<Room>().CanGoNorth();
        canGoEast = currentLocation.GetComponent<Room>().CanGoEast();
        canGoSouth = currentLocation.GetComponent<Room>().CanGoSouth();
        canGoWest = currentLocation.GetComponent<Room>().CanGoWest();
        commandInterface.GetComponent<CommandInterface>().UpdateDirectionsCrewMemberCanTravel(canGoNorth, canGoEast, canGoSouth, canGoWest);
        commandInterface.GetComponent<CommandInterface>().UpdateCrewMemberProfile();
    }

}
