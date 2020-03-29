using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Room Event", fileName = "New Room Event")]
public class RoomEvent : ScriptableObject
{
    public new string name;
    public string description;
    public string buttonText; //Button text can change to match the 'nature' of the event. For example, if the event is about an enemy encounter the button could simply say "FIGHT!" instead of simply "continue". 

    //Each room event checks a specific stat
    public Stat statChecked;

    //Good outcomes
    public Stat goodOutcomeStatAffected; //Which of the player's stats will a good outcome affect?
    public int goodOutcomeStatDifference; //How much will that stat change (can be positive or negative).
    public string goodOutcomeText; //Message that will be displayed to the player on a good outcome.

    //Neutral outcomes
    public Stat neutralOutcomeStatAffected;
    public int neutralOutcomeStatDifference;
    public string neutralOutcomeText;

    //Bad outcomes
    public Stat badOutcomeStatAffected;
    public int badOutcomeStatDifference;
    public string badOutcomeText;

}
