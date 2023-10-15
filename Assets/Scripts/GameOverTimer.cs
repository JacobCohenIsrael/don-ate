using System;
using TMPro;
using UnityEngine;

public class GameOverTimer : MonoBehaviour
{
    [SerializeField] private Counter timeLeft;
    [SerializeField] private TextMeshProUGUI timeLeftText;

    private void Awake()
    {
        timeLeft.OnChange += OnTimeLeftChanged;
    }

    private void OnDestroy()
    {
        timeLeft.OnChange -= OnTimeLeftChanged;
    }

    private void OnTimeLeftChanged(object sender, EventArgs e)
    {
        timeLeftText.text = $"{timeLeft.Value}";
    }
}
