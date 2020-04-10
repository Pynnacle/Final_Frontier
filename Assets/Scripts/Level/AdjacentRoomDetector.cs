using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AdjacentRoomDetector : MonoBehaviour
{
    //Detecting Adjacent Rooms
    public float magnitude;
    public bool hit;
    public string layerToAvoid;
    public Color noAdjacentRoomDetected;
    public Color adjacentRoomDetected;

    public GameObject adjacentRoom;

    // <Summary> This update loop is no longer necessary and can be completely commented out or removed.
    /*
    void Update()
    {
        CheckForAdjacentRoom();
        if (hit)
        {
            Debug.DrawRay(transform.position, transform.right * magnitude, adjacentRoomDetected);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right * magnitude, noAdjacentRoomDetected);
        }
    }
    */


    /* <Summary> Raycast is used to check for an adjacent room.
     * If a room is found this method will return true, if not this method will return false.
     */
    public void CheckForAdjacentRoom()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hitInfo;

        int layerMask = 1 << LayerMask.NameToLayer(layerToAvoid);

        hit = Physics.Raycast(ray, out hitInfo, magnitude, layerMask);

        if (hit)
        {
            adjacentRoom = hitInfo.collider.gameObject;
        }
    }

    public GameObject ReturnAdjacentRoom()
    {
        return (adjacentRoom);
    }

}
