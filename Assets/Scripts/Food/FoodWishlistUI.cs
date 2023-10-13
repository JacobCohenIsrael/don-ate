using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodWishlistUI : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private FoodData foodData;
    
    public void Init(FoodData data)
    {
        foodData = data;
    }

    private void Start()
    {
        image.sprite = foodData.Sprite;
        image.preserveAspect = true;
    }
}
