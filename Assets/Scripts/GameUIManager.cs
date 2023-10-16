using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deliveredTMP;

    [SerializeField] private Counter delivered;
    [SerializeField] private GameEvent gameOverEvent;

    private void Awake()
    {
        delivered.OnChange += OnDeliver;
        gameOverEvent.RegisterListener(OnGameOver);
        delivered.Reset();
    }

    private void OnDestroy()
    {
        delivered.OnChange -= OnDeliver;
        gameOverEvent.UnregisterListener(OnGameOver);

    }

    private void OnGameOver()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDeliver(object sender, EventArgs e)
    {
        deliveredTMP.text = $"{delivered.Value}: דוקינ";
    }
}