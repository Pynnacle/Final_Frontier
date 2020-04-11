using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnexploredRoomEffect : MonoBehaviour
{
    // Destroy the effect when a new room spawns on top of it
    void OnTriggerEnter()
    {
        gameObject.SetActive(false);
    }

}
