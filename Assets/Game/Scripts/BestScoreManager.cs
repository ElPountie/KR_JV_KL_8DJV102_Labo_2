using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    string m_FileName = "BestScores.json";
    BestScores m_BestScores;
    // Start is called before the first frame update
    void Start()
    {
        string json;
        if (FileManager.LoadFromFile(m_FileName, out json))
        {
            m_BestScores = new BestScores();
            m_BestScores.LoadFromJson(json);
        }
        else
        {
            m_BestScores = new BestScores();
            for (int i = 0; i < 5; i++)
            {
                BestScores.ScoreData scoreData = new BestScores.ScoreData();
                scoreData.Name = "AAA";
                scoreData.Score = 0;
                m_BestScores.ScoresData.Add(scoreData);
            }
        }
    }

    public void SaveScore()
    {
        FileManager.WriteToFile(m_FileName, m_BestScores.ToJson());
    }

    public BestScores getBestScore()
    {
        return m_BestScores;
    }

    public bool AddScore(string name, int score)
    {
        for (int i = 0; i < 5; i++)
        {
            if (score > m_BestScores.ScoresData[i].Score)
            {
                BestScores.ScoreData scoreData = new BestScores.ScoreData();
                scoreData.Name = name;
                scoreData.Score = score;
                m_BestScores.ScoresData.Insert(i, scoreData);
                m_BestScores.ScoresData.RemoveAt(5);
                SaveScore();
                return true;
            }
        }
        return false;
    }
}
