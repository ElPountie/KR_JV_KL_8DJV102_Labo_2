using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBall : MonoBehaviour
{
    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void AddScore(int points)
    {
        scoreManager.AddScore(points);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreObject scoreObject;
        collision.gameObject.TryGetComponent<ScoreObject>(out scoreObject);
        if(scoreObject != null)
        {
            AddScore(scoreObject.points);
        }
    }
}
