using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSwitcher : Button
{
    public enum ButtonColor { Red, Green, Blue, Yellow};
    public ButtonColor color;

    private Note note;

    public void Start()
    {
        note = new Note();
        
        switch(color)
        {
            case ButtonColor.Red:
                note.type = Note.NoteType.Red;
                break;
            case ButtonColor.Blue:
                note.type = Note.NoteType.Blue;
                break;
            case ButtonColor.Yellow:
                note.type = Note.NoteType.Yellow;
                break;
            case ButtonColor.Green:
                note.type = Note.NoteType.Green;
                break;
        }
    }
    public override void PerformAction()
    {
        PlayerManager.instance.UpdatePlayerNote(note);
    }
}
