using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMember : MonoBehaviour
{
    public new string name;

    //Statistics
    public int power;
    public int agility;
    public int intellect;
    public int endurance;

    //Movement
    public float moveDuration;
    float startTime = 0f, timeElapsed;
    Vector3 startPosition, endPosition;
    bool isMoving;

    //References
    public GameObject currentLocation; //Reference to the room crew member is in.
    public GameObject commandInterface; //Reference to the command interface.

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
                return;
            }

            transform.position = Vector3.Lerp(startPosition, endPosition, percent);
        }
    }

    //Called when a direction on the command interface is clicked
    //Causes the code in the this.update loop to run.
    public void Move(GameObject targetRoom)
    {
        isMoving = true;
        startTime = Time.time;
        startPosition = transform.position;
        endPosition = new Vector3(targetRoom.transform.position.x, transform.position.y, targetRoom.transform.position.z);
        currentLocation = targetRoom;
    }

    void OnMouseDown()
    {
        Debug.Log(name + " was selected.");
        commandInterface.SetActive(true);
        UpdateCommandInterface();
        
    }

    void UpdateCommandInterface()
    {
        commandInterface.GetComponent<CommandInterface>().selectedCrewMember = gameObject;
        canGoNorth = currentLocation.GetComponent<Room>().CanGoNorth();
        canGoEast = currentLocation.GetComponent<Room>().CanGoEast();
        canGoSouth = currentLocation.GetComponent<Room>().CanGoSouth();
        canGoWest = currentLocation.GetComponent<Room>().CanGoWest();
        commandInterface.GetComponent<CommandInterface>().UpdateDirectionsCrewMemberCanTravel(canGoNorth, canGoEast, canGoSouth, canGoWest);
    }

}
