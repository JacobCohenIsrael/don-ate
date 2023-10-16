﻿using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI highScoreAlertText;
    [SerializeField] private Counter delivered;

    [SerializeField] private GameEvent gameOverEvent;

    private void Awake()
    {
        gameOverEvent.RegisterListener(OnGameOver);
        this.gameObject.SetActive(false);
    }

    public void OnGameOver()
    {
        this.gameObject.SetActive(true);

        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        float score = delivered.Value;

        scoreText.text = $"שימחת {score} חיילות וחיילים!";

        if(score > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
            highScore = score;
            highScoreAlertText.gameObject.SetActive(true);
        }

        highScoreText.text = $"שיא: {highScore}!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void OnDestroy()
    {
        gameOverEvent.UnregisterListener(OnGameOver);

    }
}