using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameName;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject gameImge;
    public GameObject gameManuBackround;
    public GameObject pauseButton;
    public GameObject score;

    public GameObject coutdownLayer;
    public GameObject coutdownText;
    public GameObject coutdownMessage;

    public GameObject ReplayPagePanel;
    public GameObject RestartButton;
    public GameObject RestartExitButton;
    public GameObject YourScore;
    public GameObject BestScore;

    public Text BestScoreText;

    public Text yourScore;
    public Text BestScoreTextTwo;

    



    private int scoreInt;
    public Text scroreText;

    private int highScore;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }

        BestScoreText.text = highScore.ToString();
        yourScore.text = scoreInt.ToString();

    }


    public void Start()
    {
        coutdownLayer.SetActive(false);
        coutdownText.SetActive(false);
        coutdownMessage.SetActive(false);

        pauseButton.SetActive(false);
        score.SetActive(false);

        ReplayPagePanel.SetActive(false);
        RestartButton.SetActive(false);
        RestartExitButton.SetActive(false);
        YourScore.SetActive(false);
        BestScore.SetActive(false);


        scoreInt = 0;
        scroreText.text = scoreInt.ToString();
    }


    public void PlayGame()
    {

        gameName.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        gameImge.SetActive(false);
        gameManuBackround.SetActive(false);
        pauseButton.SetActive(false);
        score.SetActive(false);

        coutdownLayer.SetActive(true);
        coutdownText.SetActive(true);
        coutdownMessage.SetActive(true);

        GameManager.instante.gameStates = GameManager.GameStates.countdown;
        StartCoroutine("IncreaseScore");

    }


    public void RestartGame()
    {
         SceneManager.LoadScene(0);
    }


    public void ActivateRestartUI()
    {
        ReplayPagePanel.SetActive(true);
        RestartButton.SetActive(true);
        RestartExitButton.SetActive(true);
        YourScore.SetActive(true);
        BestScore.SetActive(true);

        pauseButton.SetActive(false);
        score.SetActive(false);

        yourScore.text = scoreInt.ToString();
        BestScoreTextTwo.text = highScore.ToString();
    }




    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }


    IEnumerator IncreaseScore()
    {

     
        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
            {
                scoreInt += 1;
                scroreText.text = scoreInt.ToString();
            }
            yield return new WaitForSeconds(0.4f);

        }

    }


    public void SaveGameData()
    {
        if (scoreInt > highScore)
        {
            highScore = scoreInt;
        }

        PlayerPrefs.SetInt("highScore", highScore);
      

    }

}
