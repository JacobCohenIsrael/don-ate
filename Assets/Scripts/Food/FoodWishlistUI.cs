using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodWishlistUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ContactPointController contactPointController;
    [SerializeField] private FoodData foodData;

    private void Awake()
    {
        contactPointController.onWishFulfilledEvent += OnWishFulfilled;
    }

    private void OnWishFulfilled(object sender, EventArgs e)
    {
        this.gameObject.SetActive(false);
    }

    public void Init(FoodData data)
    {
        foodData = data;
        image.sprite = foodData.Sprite;
        image.preserveAspect = true;
    }

    private void OnDestroy()
    {
        contactPointController.onWishFulfilledEvent -= OnWishFulfilled;
    }
}
