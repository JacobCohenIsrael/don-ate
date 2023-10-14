using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodUIItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image selectedImage;
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    [SerializeField] private GameEventArg onFoodChangeEvent;

    private FoodData foodData;


    private void Awake()
    {
        button.onClick.AddListener(OnFoodChangeButtonClicked);
        onFoodChangeEvent.RegisterListener(OnFoodChanged);
    }



    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnFoodChangeButtonClicked);
        onFoodChangeEvent.UnregisterListener(OnFoodChanged);
    }

    public void Init(FoodData data)
    {
        foodData = data;
        title.text = data.Title;
        image.sprite = data.Sprite;
        image.preserveAspect = true;
    }
    
    private void OnFoodChangeButtonClicked()
    {
        onFoodChangeEvent.Raise(foodData.FoodPrefab);
        selectedImage.enabled = true;
    }
    
    private void OnFoodChanged(object obj)
    {
        selectedImage.enabled = false;
    }
}
