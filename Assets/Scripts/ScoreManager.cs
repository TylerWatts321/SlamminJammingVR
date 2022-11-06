using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    static int comboScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }
    public static void Hit()
    {
        comboScore += 1;
        Instance.hitSFX.Play();
        PlayerStats.instance.AddScore(comboScore);
    }
    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.Play();
        PlayerStats.instance.RemoveScore(10);
    }
    private void Update()
    {
        
    }
}
