using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Melanchall.DryWetMidi.Interaction;
using System;
public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction; //associates a note with a lane
    public KeyCode input; //input, will have to eventually tie with the buttons ########
    public GameObject notePrefab; //the actual note objects that will spawn
    List<Note> notes = new List<Note>(); //array to keep track of the different notes
    public List<double> timeStamps = new List<double>(); //the time where the note needs to be tapped

    int spawnIndex = 0; //
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array) //filters out the notes that we don't need 
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count) //for spawning notes
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime) //checks if it's time for the note to spawn
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>()); //adds note to list
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++; //keeps track of the note that needs to be spawned
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError; //the space which the note can register when tapped 
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(input))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError) //the player hits the note correctly
                {
                    Hit();
                    print($"Hit on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else //the player misses
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (timeStamp + marginOfError <= audioTime) //the player doesn't tap at all
            {
                Miss();
                print($"Missed {inputIndex} note");
                inputIndex++;
            }
        }

    }
    private void Hit()
    {
        ScoreManager.Hit();
    }
    private void Miss()
    {
        ScoreManager.Miss();
    }
}
