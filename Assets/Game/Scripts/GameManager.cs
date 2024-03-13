using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    MainMenu MainMenu;
    ScoreManager scoreManager;
    BestScoreManager bestScoreManager;
    public GameObject ballPrefab;
    PlayerInputActions InputAction;
    InputAction MultiBallAction;
    InputAction PauseGameAction;
    public Vector3 ballPosition;
    public float ballOffset = 0.3f;
    int nbBall = 0;
    bool multiBall = false;
    // Start is called before the first frame update
    private void Awake()
    {
        InputAction = new PlayerInputActions();
    }

    private void OnEnable()
    {
        MultiBallAction = InputAction.Player.MultiBall;
        PauseGameAction = InputAction.Player.Pause;

        MultiBallAction.Enable();
        MultiBallAction.started += setMultiBall;

        PauseGameAction.Enable();
        PauseGameAction.started += PauseGame;
    }

    private void OnDisable()
    {
        MultiBallAction.started -= setMultiBall;
        PauseGameAction.started -= PauseGame;
        MultiBallAction.Disable();
        PauseGameAction.Disable();
    }
    void Start()
    {
        MainMenu = GameObject.FindObjectOfType<MainMenu>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        bestScoreManager = GameObject.FindObjectOfType<BestScoreManager>();
    }

    public void StartGame()
    {
        multiBall = false;
        if(nbBall > 0)
        {
            foreach (ScoreBall objec in GameObject.FindObjectsOfType<ScoreBall>())
            {
                Destroy(objec.gameObject);
            }
            nbBall = 0;
        }
        MainMenu.HideMenu();
        MainMenu.gameObject.SetActive(false);
        Instantiate(ballPrefab, ballPosition, Quaternion.identity);
        nbBall++;
    }

    void EndGame()
    {
        MainMenu.gameObject.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            if (scoreManager.GetScore() > bestScoreManager.getBestScore().ScoresData[i].Score)
            {
                askName();
                return;
            }
        }
        MainMenu.showScore(scoreManager.GetScore());
        scoreManager.ResetScore();
    }

    void PauseGame(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    void askName()
    {
        MainMenu.InputMenu.SetActive(true);
    }

    public void SaveScore(string name)
    {
        int score = scoreManager.GetScore();
        bestScoreManager.AddScore(name, score);
        MainMenu.showScore(score);
        scoreManager.ResetScore();
    }

    public void RemoveBall()
    {
        nbBall--;
        if(nbBall == 0)
        {
            EndGame();
        }
    }

    void AddBall()
    {
        nbBall++;
    }

    void setMultiBall(InputAction.CallbackContext context)
    {
        if (multiBall)
        {
            return;
        }
        multiBall = true;
        nbBall += 2;
        Vector3 spawnBall = ballPosition + new Vector3(0, 0, -ballOffset);
        Instantiate(ballPrefab, spawnBall, Quaternion.identity);
        spawnBall -= new Vector3(0, 0, -ballOffset);
        Instantiate(ballPrefab, spawnBall, Quaternion.identity);
    }
}
