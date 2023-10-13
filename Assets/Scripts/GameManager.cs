using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Counter combo;
    [SerializeField] private GameEvent comboStreakEvent;

    private long previousStreak;
    
    private void Awake()
    {
        combo.OnChange += OnComboChange;
    }

    private void OnDestroy()
    {
        combo.OnChange -= OnComboChange;
    }

    private void OnComboChange(object sender, EventArgs e)
    {
        if (combo.Value > previousStreak && combo.Value % 5 == 0)
        {
            comboStreakEvent.Raise();
            previousStreak = combo.Value;
            Debug.Log($"Combo Streak {combo.Value}");
        }
    }
}
