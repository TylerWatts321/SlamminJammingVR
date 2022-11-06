using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Note currentNote;
    public bool playerHit = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }

    public void Start()
    {
        currentNote = new Note();
        currentNote.type = Note.NoteType.Down;
    }

    public void UpdatePlayerNote(Note note)
    {
        currentNote = note;
        UIManager.instance.SwapNoteColor(currentNote.type);
    }

    
}
