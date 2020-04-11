using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class FFGameManager : MonoBehaviour
{
    //Analytics
    public static int newRoomsExplored;
    public static int goodEventOutcomes;
    public static int badEventOutcomes;
    public static int whichTurnTheObjectiveWasFound;

    public GameObject missionCompleteBanner, missionFailedBanner, gotPowerCellBanner, missionObjective; 
    public Text turnNumberDisplay;


    public int turnNumber = 1;
    public int turnLimit;
    public CrewMember[] crewMembersInMission;


    void Update()
    {

        if(crewMembersInMission[0].turnIsOver && crewMembersInMission[1].turnIsOver)
        {
            turnNumber++;
            turnNumberDisplay.text = "Turn " + turnNumber.ToString();
            //...
            foreach (CrewMember crewMember in crewMembersInMission)
            {
                crewMember.turnIsOver = false;
                crewMember.movesRemaining = crewMember.agility;
                crewMember.selectableIndication.SetActive(true);
            }

            if (turnNumber > turnLimit) //Shouldn't use >= because we want the last turn to end.
            {
                MissionFailed();
            }

        }

    }

    public void MissionComplete()
    {
        missionCompleteBanner.SetActive(true);
        SendAnalytics();
    }

    public void MissionFailed()
    {
        missionFailedBanner.SetActive(true);
        SendAnalytics();
    }

    public void FoundPowerCell()
    {
        gotPowerCellBanner.SetActive(true);
        whichTurnTheObjectiveWasFound = turnNumber;
    }

    public void HideGotPowerCellBanner()
    {
        gotPowerCellBanner.SetActive(false);
    }

    public void HideMissionObjective()
    {
        missionObjective.SetActive(false);
    }

    void SendAnalytics()
    {
        // 1. How much time the mission took.
        Analytics.CustomEvent("Mission Play Time", new Dictionary<string, object>
    {
        { "Mission Play Time", Time.timeSinceLevelLoad }
    });

        // 2. How many new rooms were explored.
        Analytics.CustomEvent("Number of New Rooms Explored", new Dictionary<string, object>
    {
        { "Number of New Rooms Explored", newRoomsExplored }
    });

        // 3. How many event outcomes were good.
        Analytics.CustomEvent("Number of Good Outcomes", new Dictionary<string, object>
    {
        { "Number of Good Outcomes", goodEventOutcomes }
    });

        // 4. How many event outcomes were bad.
        Analytics.CustomEvent("Number of Bad Outcomes", new Dictionary<string, object>
    {
        { "Number of Bad Outcomes", badEventOutcomes }
    });

        // 5. On which turn was the objective found.
        Analytics.CustomEvent("Which Turn Power Cell Was Obtained", new Dictionary<string, object>
    {
        { "Which Turn Power Cell Was Obtained", whichTurnTheObjectiveWasFound }
    });
    }
}
