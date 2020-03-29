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

    //A room event is triggered when a crew member walks into an unexplored room.
    public string Triggered(GameObject selectedCrewMember)
    {
        int randomNum = Random.Range(1, 11); //Generate a random whole number between 1 and 10.

        /* So what's going on here is:
         * 
         * 
         * 
         * 
         * 
         */
        switch (statChecked)
        {
            case Stat.POWER:
                
                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().power >= 9) {
                    switch(goodOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += goodOutcomeStatDifference;
                            break;
                    }

                    return (goodOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().power > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().power < 9) { //4 - 8

                    switch (neutralOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += neutralOutcomeStatDifference;
                            break;
                    }

                    return (neutralOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().power <= 3) {

                    switch (badOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += badOutcomeStatDifference;
                            break;
                    }

                    return (badOutcomeText);
                }

                break;

            case Stat.AGILITY:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().agility >= 9) {

                    switch (goodOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += goodOutcomeStatDifference;
                            break;
                    }

                    return (goodOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().agility > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().agility < 9) { //4 - 8

                    switch (neutralOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += neutralOutcomeStatDifference;
                            break;
                    }

                    return (neutralOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().agility <= 3) {

                    switch (badOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += badOutcomeStatDifference;
                            break;
                    }

                    return (badOutcomeText);
                }

                break;

            case Stat.INTELLECT:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect >= 9) {

                    switch (goodOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += goodOutcomeStatDifference;
                            break;
                    }

                    return (goodOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect < 9) { //4 - 8

                    switch (neutralOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += neutralOutcomeStatDifference;
                            break;
                    }

                    return (neutralOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().intellect <= 3) {

                    switch (badOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += badOutcomeStatDifference;
                            break;
                    }

                    return (badOutcomeText);
                }

                break;

            case Stat.ENDURANCE:

                if (randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance >= 9) {

                    switch (goodOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += goodOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += goodOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += goodOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += goodOutcomeStatDifference;
                            break;
                    }

                    return (goodOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance > 3 && randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance < 9) { //4 - 8

                    switch (neutralOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += neutralOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += neutralOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += neutralOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += neutralOutcomeStatDifference;
                            break;
                    }

                    return (neutralOutcomeText);

                } else if (randomNum + selectedCrewMember.GetComponent<CrewMember>().endurance <= 3) {

                    switch (badOutcomeStatAffected) {
                        case Stat.POWER:
                            selectedCrewMember.GetComponent<CrewMember>().power += badOutcomeStatDifference;
                            break;
                        case Stat.AGILITY:
                            selectedCrewMember.GetComponent<CrewMember>().agility += badOutcomeStatDifference;
                            break;
                        case Stat.INTELLECT:
                            selectedCrewMember.GetComponent<CrewMember>().intellect += badOutcomeStatDifference;
                            break;
                        case Stat.ENDURANCE:
                            selectedCrewMember.GetComponent<CrewMember>().endurance += badOutcomeStatDifference;
                            break;
                    }

                    return (badOutcomeText);
                }
                break;

        }

        return ("shothouse"); //Should never be reached.

    }


}
