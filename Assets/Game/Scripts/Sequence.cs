using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    public Material checkMaterial;
    public TriggerHandler triggerHandler;
    private bool isTriggered = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PinBall") && !isTriggered)
        {
            GetComponent<Renderer>().material = checkMaterial;
            isTriggered = true;
            triggerHandler.TriggerActivated();
        }
        
       
    }
}
