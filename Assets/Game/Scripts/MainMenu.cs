using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameObject bestScorePanel;
    GameObject mainMenuPanel;
    GameObject playerScore;
    public GameObject InputMenu;
    BestScoreManager bestScoreManager;
    GameManager gameManager;
    //text tmp;
    TMP_Text[] names = new TMP_Text[5];
    TMP_Text[] bestScores = new TMP_Text[5];
    TMP_Text LastPlayerScore;
    TMP_Text PlayerScoreText;
    TMP_InputField inputName;

    // Start is called before the first frame update
    void Start()
    {
        bestScorePanel = transform.Find("BestScoreMenu").gameObject;
        mainMenuPanel = transform.Find("MainMenu").gameObject;
        playerScore = bestScorePanel.transform.Find("Player").gameObject;
        InputMenu = transform.Find("InputMenu").gameObject;
        bestScoreManager = GameObject.FindObjectOfType<BestScoreManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        for (int i = 0; i < 5; i++)
        {
            names[i] = bestScorePanel.transform.Find("Name" + (i + 1)).GetComponent<TMP_Text>();
            bestScores[i] = bestScorePanel.transform.Find("Score" + (i + 1)).GetComponent<TMP_Text>();
        }

        LastPlayerScore = playerScore.transform.Find("PlayerScore").GetComponent<TMP_Text>();
        PlayerScoreText = playerScore.transform.Find("PlayerScoreText").GetComponent<TMP_Text>();
        inputName = InputMenu.transform.Find("InputName").GetComponent<TMP_InputField>();

        playerScore.SetActive(false);
        bestScorePanel.SetActive(false);
        InputMenu.SetActive(false);

    }

    public void HideMenu()
    {
        mainMenuPanel.SetActive(false);
    }

    public void onPlay()
    {
        gameManager.StartGame();
    }

    public void onBestScore()
    {
        mainMenuPanel.SetActive(false);
        bestScorePanel.SetActive(true);
        setBestScore();
    }

    public void onInputName()
    {
        gameManager.SaveScore(inputName.text);
        inputName.text = "Enter your name";
        InputMenu.SetActive(false);
    }
    public void showScore(int score)
    {
        setBestScore();
        LastPlayerScore.text = score.ToString("000000");
        mainMenuPanel.SetActive(false);
        bestScorePanel.SetActive(true);
        playerScore.SetActive(true);
    }

    public void showInputMenu()
    {
        mainMenuPanel.SetActive(false);
        InputMenu.SetActive(true);     
    }

    public void setBestScore()
    {
        BestScores _bestScores = bestScoreManager.getBestScore();
        for (int i = 0; i < 5; i++)
        {
            names[i].text = _bestScores.ScoresData[i].Name + " :";
            bestScores[i].text = _bestScores.ScoresData[i].Score.ToString("000000");
        }
    }

    public void onBack()
    {
        bestScorePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void onQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
