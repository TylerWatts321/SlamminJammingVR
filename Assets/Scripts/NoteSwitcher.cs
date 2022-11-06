using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSwitcher : Button
{
    public Note.NoteType type;

    private Note note;

    public void Start()
    {
        note = new Note();

        note.type = type;
    }
    public override void PerformAction()
    {
        PlayerManager.instance.UpdatePlayerNote(note);
    }
}
