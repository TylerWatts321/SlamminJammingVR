using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private Image noteColor;
    
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
    
    public void SwapNoteColor(Note.NoteType noteType)
    {
        Color newColor = Color.black;
        switch(noteType)
        {
            case Note.NoteType.Left:
                newColor = Color.red;
                break;
            case Note.NoteType.Down:
                newColor = Color.green;
                break;
            case Note.NoteType.Right:
                newColor = Color.blue;
                break;
            case Note.NoteType.Up:
                newColor = Color.yellow;
                break;
        }
        noteColor.color = newColor;
    }
}
