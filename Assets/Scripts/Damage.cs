using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Button
{
    public override void PerformAction()
    {
        PlayerManager.instance.playerHit = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(handToCheck.ToString()))
            PlayerManager.instance.playerHit = false;
    }

}
