using System.Collections.Generic;
using UnityEngine;

public class FoodBarView : MonoBehaviour
{
    [SerializeField] private List<FoodData> foodDataList;
    [SerializeField] private FoodUIItem foodUIItemPrefab;
    [SerializeField] private Transform horizontalLayoutTransform;
    private void Awake()
    {
        foodDataList.ForEach(foodData =>
        {
            var foodUIItem = Instantiate(foodUIItemPrefab, horizontalLayoutTransform);
            foodUIItem.Init(foodData);
        });
    }
}
