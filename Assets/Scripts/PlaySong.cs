using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : Button
{
    public override void PerformAction()
    {
        FindObjectOfType<SongManager>().enabled = true;
    }
}
