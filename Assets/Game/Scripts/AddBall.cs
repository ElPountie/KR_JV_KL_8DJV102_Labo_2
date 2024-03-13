using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public Vector3 startPosition;
    // get reference to the game manager
    GameManager gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BumperAdd"))
        {
            Instantiate(ballPrefab, startPosition, Quaternion.identity);    
            gameManager.AddBall();
        }
    }
}
