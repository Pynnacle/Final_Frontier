using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FFGameManager : MonoBehaviour
{
    //Analytics
    public static int newRoomsExplored;
    public static int goodEventOutcomes;
    public static int badEventOutcomes;
    public static int whichTurnTheObjectiveWasFound;

    int turnNumber;
    public int turnLimit;
    public CrewMember[] crewMembersInMission;


    void Update()
    {

        if(crewMembersInMission[0].turnIsOver && crewMembersInMission[1].turnIsOver)
        {
            turnNumber++;
            //
            foreach (CrewMember crewMember in crewMembersInMission)
            {
                crewMember.turnIsOver = false;
            }

            if (turnNumber >= turnLimit)
            {
                //Failure
            }

        }

    }

    void SendAnalytics()
    {
        // 1. How many new rooms were explored.
        Analytics.CustomEvent("new_rooms_explored", new Dictionary<string, object>
    {
        { "new_rooms_explored", newRoomsExplored }
    });

        // 2. How much time the mission took.
        Analytics.CustomEvent("mission_time", new Dictionary<string, object>
    {
        { "mission_time", Time.timeSinceLevelLoad }
    });

        // 3. How many event outcomes were good.
        Analytics.CustomEvent("mission_time", new Dictionary<string, object>
    {
        { "mission_time", Time.timeSinceLevelLoad }
    });

        // 4. How many event outcomes were bad.
        Analytics.CustomEvent("mission_time", new Dictionary<string, object>
    {
        { "mission_time", Time.timeSinceLevelLoad }
    });

        // 5. On which turn was the objective found.
        Analytics.CustomEvent("mission_time", new Dictionary<string, object>
    {
        { "mission_time", Time.timeSinceLevelLoad }
    });
    }
}
