using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note
{
    public enum NoteType { Red, Green, Blue, Yellow };
    public NoteType type;
}
