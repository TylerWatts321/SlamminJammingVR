using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f; //at 120bpm it'll move at a rate of 2 units per second (120/60 = 2)
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)  
        {
            if(Input.anyKeyDown)   //can change to key that starts the game
            {
                hasStarted = true;
            }
        }    
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f); //moves the block in the y component
        }
    }
}
