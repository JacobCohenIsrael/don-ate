using UnityEngine;
using UnityEngine.UI;

public class FoodWishlistUI : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private FoodData foodData;
    
    public void Init(FoodData data)
    {
        foodData = data;
        image.sprite = foodData.Sprite;
        image.preserveAspect = true;
    }

    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}
