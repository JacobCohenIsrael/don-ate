using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Counter combo;
    [SerializeField] private GameEvent comboStreakEvent;
    [SerializeField] private Counter timeLeft;
    [SerializeField] private GameEvent gameOverEvent;
    [SerializeField] private long gameDurationInSeconds;
    
    private long previousStreak;
    private void Awake()
    {
        combo.Reset();
        combo.OnChange += OnComboChange;
    }

    private void Start()
    {
        timeLeft.Reset(gameDurationInSeconds);
        StartCoroutine(CountDownToGameOver());
    }

    private void OnDestroy()
    {
        combo.OnChange -= OnComboChange;
    }

    private void OnComboChange(object sender, EventArgs e)
    {
        if (combo.Value > previousStreak)
        {
            comboStreakEvent.Raise();
            previousStreak = combo.Value;
        }
    }
    
    private IEnumerator CountDownToGameOver()
    {
        yield return new WaitForSeconds(3);
        while (timeLeft.Value > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft.Decrement();
        }
        gameOverEvent.Raise();
        yield return null;
    }
}
