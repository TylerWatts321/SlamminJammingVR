using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public AudioSource hitSFX;    // Hit + Miss sound effects
    public AudioSource missSFX;

    //public TMPro.TextMeshPro scoreText;
    static int comboScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }
    public static void Hit() //plays the hit sound effect and adds combo
    {
        comboScore += 1;
        Instance.hitSFX.Play();
    }
    public static void Miss() //plays miss sound effect and loses combo
    {
        comboScore = 0;
        Instance.missSFX.Play();
    }
    private void Update() //converts the combo score to a string
    {
        //scoreText.text = comboScore.ToString();
    }
}