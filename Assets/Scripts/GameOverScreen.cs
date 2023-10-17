using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI highScoreAlertText;
    [SerializeField] private Counter delivered;

    [SerializeField] private GameEvent gameOverEvent;
    [SerializeField] private AudioSource gameOverAudioSource;

    private void Awake()
    {
        gameOverEvent.RegisterListener(OnGameOver);
        gameObject.SetActive(false);
    }

    public void OnGameOver()
    {
        gameObject.SetActive(true);
        gameOverAudioSource.Play();
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        float score = delivered.Value;

        scoreText.text = $"!םילייחו תולייח {score} תחמיש";

        if(score > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
            highScore = score;
            highScoreAlertText.gameObject.SetActive(true);
        }

        highScoreText.text = $"!{highScore}: איש";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void OnDestroy()
    {
        gameOverEvent.UnregisterListener(OnGameOver);

    }
}
