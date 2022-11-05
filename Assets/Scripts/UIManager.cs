using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private TMPro.TextMeshProUGUI noteText;
    
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
            case Note.NoteType.Red:
                newColor = Color.red;
                break;
            case Note.NoteType.Green:
                newColor = Color.green;
                break;
            case Note.NoteType.Blue:
                newColor = Color.blue;
                break;
            case Note.NoteType.Yellow:
                newColor = Color.yellow;
                break;
        }
        noteText.color = newColor;
    }
}
