using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BestScores
{
    [System.Serializable]
    public struct ScoreData
    {
        public string Name;
        public int Score;
    }

    public List<ScoreData> ScoresData = new List<ScoreData>();

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}