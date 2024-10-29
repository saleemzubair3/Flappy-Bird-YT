using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText,highestScoreText;
    private int score,highestScore;
    public GameObject gameOver,playButton,HighestScore,Image,Score;
    // Start is called before t  he first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Image.SetActive(false);
        Play();
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        Score.SetActive(true);
        Image.SetActive(false);
        HighestScore.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;  
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

    }


    public void GameOver()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        highestScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOver.SetActive(true);
        playButton.SetActive(true);
        HighestScore.SetActive(true);
        Image.SetActive(true);

        Pause();

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        
        // highestScore = score;
        // highestScoreText.text = highestScore.ToString();
    }
}
