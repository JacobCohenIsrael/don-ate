using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deliveredTMP;
    [SerializeField] private TextMeshProUGUI comboTMP;

    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;

    private void Awake()
    {
        combo.OnChange += OnCombo;
        delivered.OnChange += OnDeliver;
        combo.Reset();
        delivered.Reset();
    }

    private void OnDestroy()
    {
        combo.OnChange -= OnCombo;
        delivered.OnChange -= OnDeliver;
    }

    private void OnDeliver(object sender, EventArgs e)
    {
        deliveredTMP.text = $"Delivered: {delivered.Value}";
    }
    
    private void OnCombo(object sender, EventArgs e)
    {
        comboTMP.text = $"Combo: {combo.Value}";
    }
}