using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    MainMenu MainMenu;
    int score = 0;

    void Start()
    {
        MainMenu = GameObject.FindObjectOfType<MainMenu>();
    }
    public void AddScore(int points)
    {
        score += points;
        MainMenu.UpdateScore(score);
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
