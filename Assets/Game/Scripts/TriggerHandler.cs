using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private int triggerCount = 0;

    public void TriggerActivated()
    {
        triggerCount++;

        if (triggerCount >= 2)
        {
            Debug.Log("Both triggers have been activated");
            GameObject.FindWithTag("Door").SetActive(false);
        }
    }
}
