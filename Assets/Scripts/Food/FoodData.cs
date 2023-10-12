using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "don-ate/FoodData", fileName = "Food")]
public class FoodData : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private FoodController foodPrefab;
    [SerializeField] private Sprite sprite;

    public string Title => title;
    public FoodController FoodPrefab => foodPrefab;
    public Sprite Sprite => sprite;
}
