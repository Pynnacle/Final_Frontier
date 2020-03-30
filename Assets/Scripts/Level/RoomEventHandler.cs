using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEventHandler : MonoBehaviour
{
    public GameObject roomEventPopup, outcomeOfEventPopup;
    public GameObject commandInterface;
    public Text eventName, eventDescription, eventButtonText, outcomeOfEventText;
    public RoomEvent[] roomEvents;

    RoomEvent currentEvent;
    string outcomeOfEvent;
   

    //A room event is triggered when a crew member walks into an unexplored room.
    public void TriggerRoomEvent(GameObject selectedCrewMember)
    {
        currentEvent = roomEvents[Random.Range(0, roomEvents.Length)];
        ShowRoomEventPopup();

        int randomNum = Random.Range(1, 11); //Generate a random whole number between 1 and 10.

        /* <Summary>
         * 
         * 
         * 
         * 
         */
        switch (currentEvent.statChecked)
        {
            case Stat.POWER:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().power >= 9)
                {
                    switch (currentEvent.goodOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.goodOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.goodOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().power > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().power < 9)
                { //4 - 8

                    switch (currentEvent.neutralOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.neutralOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.neutralOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().power <= 3)
                {

                    switch (currentEvent.badOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.badOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.badOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);
                }

                break;

            case Stat.AGILITY:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().agility >= 9)
                {

                    switch (currentEvent.goodOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.goodOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.goodOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().agility > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().agility < 9)
                { //4 - 8

                    switch (currentEvent.neutralOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.neutralOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.neutralOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().agility <= 3)
                {

                    switch (currentEvent.badOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.badOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.badOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);
                }

                break;

            case Stat.INTELLECT:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect >= 9)
                {

                    switch (currentEvent.goodOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.goodOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.goodOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect < 9)
                { //4 - 8

                    switch (currentEvent.neutralOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.neutralOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.neutralOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect <= 3)
                {

                    switch (currentEvent.badOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.badOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.badOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);
                }

                break;

            case Stat.ENDURANCE:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance >= 9)
                {

                    switch (currentEvent.goodOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.goodOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.goodOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance < 9)
                { //4 - 8

                    switch (currentEvent.neutralOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.neutralOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.neutralOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);

                }
                else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance <= 3)
                {

                    switch (currentEvent.badOutcomeStatAffected)
                    {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += currentEvent.badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += currentEvent.badOutcomeStatDifference;
                            break;
                    }

                    outcomeOfEvent = currentEvent.badOutcomeText.Replace("[character]", selectedCrewMember.GetComponent<CrewMember>().name);
                }
                break;
        }
    }

    void ShowRoomEventPopup()
    {
        //Update the text elements
        eventName.text = currentEvent.name;
        eventDescription.text = currentEvent.description;
        eventButtonText.text = currentEvent.buttonText;
        //Display the popup
        roomEventPopup.SetActive(true);
    }

    public void HideRoomEventPopup()
    {
        roomEventPopup.SetActive(false);
        Invoke("ShowOutcomeOfEvent", 0.5f);
    }

    void ShowOutcomeOfEvent()
    {
        outcomeOfEventText.text = outcomeOfEvent;
        outcomeOfEventPopup.SetActive(true);
    }

    public void HideOutcomeOfEvent()
    {
        outcomeOfEventPopup.SetActive(false);
        commandInterface.GetComponent<CommandInterface>().TurnEnded();
        //commandInterface.GetComponent<CommandInterface>().UpdateCrewMemberProfile();
    }
}
