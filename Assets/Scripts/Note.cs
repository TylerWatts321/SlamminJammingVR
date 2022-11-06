using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note
{
    public enum NoteType { Up, Down, Left, Right };
    public NoteType type;
}
