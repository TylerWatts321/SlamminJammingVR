using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    public enum Hand { LeftHand, RightHand};
    public Hand handToCheck;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(handToCheck.ToString()))
        {
            PerformAction();
        }
    }

    public abstract void PerformAction();
    
}
