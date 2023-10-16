using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyUI : MonoBehaviour
{
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private TextMeshProUGUI difficultyText;
    [SerializeField] private DifficultySettings easy;
    [SerializeField] private DifficultySettings normal;
    [SerializeField] private DifficultySettings hard;
    [SerializeField] private DifficultyManager difficultyManager;

    private void Awake()
    {
        difficultySlider.onValueChanged.AddListener(OnDifficultyValueChanged);
    }

    private void OnDestroy()
    {
        difficultySlider.onValueChanged.RemoveListener(OnDifficultyValueChanged);
    }

    private void Start()
    {
        difficultySlider.value = 1;
        difficultyManager.SetDifficulty(normal);
    }

    public void OnDifficultyValueChanged(float value)
    {
        var sliderValue = (int)value;
        switch (sliderValue)
        {
            case 0:
                difficultyManager.SetDifficulty(easy);
                break;
            case 1:
                difficultyManager.SetDifficulty(normal);
                break;
            case 2:
                difficultyManager.SetDifficulty(hard);
                break;
            default:
                throw new Exception("Unsupported difficulty settings");
        }

        difficultyText.text = difficultyManager.Title;
    }
}
