using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
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
        scoreText.text = $"שימחת {delivered.Value} חיילות וחיילים!";
    }

    private void OnDestroy()
    {
        gameOverEvent.UnregisterListener(OnGameOver);

    }
}
