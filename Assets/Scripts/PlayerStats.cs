using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public int maxCrowdScore;
    public int crowdScore;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }

    public void AddScore(int scoreAdded)
    {
        crowdScore += scoreAdded;
        if (maxCrowdScore < crowdScore)
            crowdScore = maxCrowdScore;
    }

    public void RemoveScore(int scoreRemoved)
    {
        crowdScore -= scoreRemoved;
        if (crowdScore <= 0)
        {
            SongManager.Instance.enabled = false;
        }
    }
}
