using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    MainMenu MainMenu;
    ScoreManager scoreManager;
    public GameObject ballPrefab;
    public PlayerInputActions InputAction;
    public InputAction MultiBallAction;
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

        MultiBallAction.Enable();
        MultiBallAction.started += setMultiBall;
    }

    private void OnDisable()
    {
        MultiBallAction.started -= setMultiBall;
        MultiBallAction.Disable();
    }
    void Start()
    {
        MainMenu = GameObject.FindObjectOfType<MainMenu>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
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
        MainMenu.gameObject.SetActive(false);
        Instantiate(ballPrefab, ballPosition, Quaternion.identity);
    }

    void EndGame()
    {
        MainMenu.gameObject.SetActive(true);
        MainMenu.showScore(scoreManager.GetScore());
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
