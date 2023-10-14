using System.Collections.Generic;
using UnityEngine;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private FoodData[] foodDataArray;

    [SerializeField] private FoodWishlistUI wishlistUI;
    
    private FoodData wishlist;
    
    void Start()
    {
        var foodData = foodDataArray[Random.Range(0, foodDataArray.Length)];
        wishlist = foodData;
        wishlistUI.Init(foodData);
    }

    private void OnTriggerEnter(Collider other)
    {
        var food = other.gameObject.GetComponent<FoodController>();
        if (food == null) return;

        if (food.foodData != wishlist)
        {
            // Calculate a random force within the specified range
            float randomForce = Random.Range(5, 20);

            // Generate a random direction with some divergence
            Vector3 randomDirection = Quaternion.Euler(Random.Range(-30, 30), Random.Range(0, 360), 0) * Vector3.up;

            // Apply the force to the Rigidbody
            food.GetComponent<Rigidbody>().AddForce(randomDirection * randomForce, ForceMode.Impulse);
            return;
        }
        
        delivered.Increment();
        combo.Increment();
        food.OnDelivery();
        audioSource.Play();
    }
}