using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AdjacentRoomDetector : MonoBehaviour
{
    public float magnitude;
    public Color noAdjacentRoomDetected;
    public Color adjacentRoomDetected;
    public bool hit;
    public string layerToAvoid;

    void Update()
    {

        Debug.Log("Running running running");

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        int layerMask = 1 << LayerMask.NameToLayer(layerToAvoid);
        //If you want to add more layers to search for, add them here^.

        hit = Physics.Raycast(ray, out hitInfo, magnitude, layerMask);

        //Debug.DrawRay(transform.position, Vector3.forward * magnitude, Color.red);

        if (hit) {
            Debug.DrawRay(transform.position, transform.forward * magnitude, adjacentRoomDetected);
        } else{
            Debug.DrawRay(transform.position, transform.forward * magnitude, noAdjacentRoomDetected);
        }


    }
}
