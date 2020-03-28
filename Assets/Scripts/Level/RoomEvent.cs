using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Room Event", fileName = "New Room Event")]
public class RoomEvent : ScriptableObject
{
    public new string name;
    public string description;
    public string buttonText;
}
