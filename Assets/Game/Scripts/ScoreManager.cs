using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    public void AddScore(int points)
    {
        score += points;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}
