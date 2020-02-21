using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AdjacentRoomDetector : MonoBehaviour
{
    public float magnitude;
    public Color safeColor;
    public Color warningColor;
    public Color hitColor;
    public bool hit;
    public float hitDistance;
    public float hitPercentage;
    public float sensitivity;

    public string layerToAvoid;

    void Update()
    {

        Debug.Log("Running running running");
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        int layerMask = 1 << LayerMask.NameToLayer(layerToAvoid);
        //If you want to add more layers to search for, add them here^.

        hit = Physics.Raycast(ray, out hitInfo, magnitude, layerMask);

        if (hit)
        {
            hitDistance = hitInfo.distance;
            hitPercentage = 1 - (hitDistance / magnitude);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.Lerp(warningColor, hitColor, hitPercentage));
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * magnitude, safeColor);
        }

    }
}
