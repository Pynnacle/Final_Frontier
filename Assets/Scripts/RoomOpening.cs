using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OpeningSide
{
    LEFT, RIGHT, TOP, BOTTOM
}

[ExecuteInEditMode]
public class RoomOpening : MonoBehaviour
{

    public OpeningSide sideOpeningIsOn;
    GameObject roomPicker;
    Vector3 newRoomPosition;
    bool alreadyCrossed; //This is a temporary fix since raycast doesn't want to cooperate.
    GameObject lastRoomGenerated;

    //Detecting Adjacent Rooms
    public float magnitude;
    public bool hit;
    public string layerToAvoid;
    public Color noAdjacentRoomDetected;
    public Color adjacentRoomDetected;

    void Start()
    {
        roomPicker = GameObject.Find("Random Room Picker");
    }

    void Update()
    {
        Debug.Log("Running running running");

        if (CheckIfAdjacentRoomExists()){

            Debug.DrawRay(transform.position, transform.right * magnitude, adjacentRoomDetected);

        } else{

            Debug.DrawRay(transform.position, transform.right * magnitude, noAdjacentRoomDetected);

        }

    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player" && !CheckIfAdjacentRoomExists())
        {
            if (sideOpeningIsOn == OpeningSide.LEFT)
            {

                newRoomPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z - 10);
                lastRoomGenerated = Instantiate<GameObject>(roomPicker.GetComponent<RoomPicker>().PickRoom(), newRoomPosition, transform.parent.transform.rotation);

            }
            else if (sideOpeningIsOn == OpeningSide.RIGHT)
            {

                newRoomPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z + 10);
                lastRoomGenerated = Instantiate<GameObject>(roomPicker.GetComponent<RoomPicker>().PickRoom(), newRoomPosition, transform.parent.transform.rotation);

            }
            else if (sideOpeningIsOn == OpeningSide.TOP)
            {

                newRoomPosition = new Vector3(transform.parent.transform.position.x - 10, transform.parent.transform.position.y, transform.parent.transform.position.z);
                lastRoomGenerated = Instantiate<GameObject>(roomPicker.GetComponent<RoomPicker>().PickRoom(), newRoomPosition, transform.parent.transform.rotation);

            }
            else if (sideOpeningIsOn == OpeningSide.BOTTOM)
            {

                newRoomPosition = new Vector3(transform.parent.transform.position.x + 10, transform.parent.transform.position.y, transform.parent.transform.position.z);
                lastRoomGenerated = Instantiate<GameObject>(roomPicker.GetComponent<RoomPicker>().PickRoom(), newRoomPosition, transform.parent.transform.rotation);

            }
        }
    }

    bool CheckIfAdjacentRoomExists()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hitInfo;

        int layerMask = 1 << LayerMask.NameToLayer(layerToAvoid);

        hit = Physics.Raycast(ray, out hitInfo, magnitude, layerMask);

        if (hit){

            Debug.Log("Detected adjacent room.");
            return (true);

        } else{

            Debug.Log("No existing room detected.");
            return (false);
        }

        
    }
}
