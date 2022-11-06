using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Button
{
    public override void PerformAction()
    {
        PlayerStats.instance.RemoveScore(20);
    }

    
}
