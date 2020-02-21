using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OpeningSide
{
    LEFT, RIGHT, TOP, BOTTOM
}

public class RoomOpening : MonoBehaviour
{

    public OpeningSide sideOpeningIsOn;
    GameObject roomPicker;
    Vector3 newRoomPosition;
    bool alreadyCrossed; //This is a temporary fix since raycast doesn't want to cooperate.

    void Start()
    {
        roomPicker = GameObject.Find("Random Room Picker");
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player" && !alreadyCrossed)
        {
            if (sideOpeningIsOn == OpeningSide.LEFT)
            {

                newRoomPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z - 10);
                GameObject temp1 = Instantiate<GameObject>(roomPicker.GetComponent<RoomPicker>().PickRoom(), newRoomPosition, transform.parent.transform.rotation);

            }
            else if (sideOpeningIsOn == OpeningSide.RIGHT)
            {

                newRoomPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z + 10);
                GameObject temp2 = Instantiate<GameObject>(roomPicker.GetComponent<RoomPicker>().PickRoom(), newRoomPosition, transform.parent.transform.rotation);

            }
            else if (sideOpeningIsOn == OpeningSide.TOP)
            {

            }
            else if (sideOpeningIsOn == OpeningSide.BOTTOM)
            {

            }

            alreadyCrossed = true;
        }
    }
}
