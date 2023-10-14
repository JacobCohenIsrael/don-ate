using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public void OnServerInitialized(int score)
    {
        this.gameObject.SetActive(true);
        scoreText.text = $"{score} Points!";
    }
}
