using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public Note.NoteType noteKey;
    public GameObject notePrefab;
    List<NoteObject> notes = new List<NoteObject>();
    public List<double> timeStamps = new List<double>();

    public Image laneImage;
    int spawnIndex = 0;
    int inputIndex = 0;

    // Start is called before the first frame update
    
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        laneImage.color = new Color(laneImage.color.r, laneImage.color.g, laneImage.color.b, 24);

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
        ShowIndicator();
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<NoteObject>());
                note.GetComponent<NoteObject>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (noteKey.Equals(PlayerManager.instance.currentNote.type) && PlayerManager.instance.playerHit)
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    print($"Hit on {inputIndex} note");
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                print($"Missed {inputIndex} note");
                inputIndex++;
            }
        }       
    
    }
    private void ShowIndicator()
    {
            
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
