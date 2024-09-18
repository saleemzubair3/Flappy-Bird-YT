using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    public GameObject gameOver;
    // Start is called before the first frame update
    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;

    }
    public void IncreaseScore()
    {
        score++;
    }
}
