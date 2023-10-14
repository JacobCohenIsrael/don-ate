using System.Collections.Generic;
using UnityEngine;
using System;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private FoodData[] foodDataArray;
    [SerializeField] private CapsuleCollider contactPointCollider;

    [SerializeField] private FoodWishlistUI wishlistUI;
    
    public event EventHandler onWishFulfilledEvent;

    private FoodData wishlist;
    
    void Start()
    {
        var foodData = foodDataArray[UnityEngine.Random.Range(0, foodDataArray.Length)];
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
            float randomForce = UnityEngine.Random.Range(5, 20);

            // Generate a random direction with some divergence
            Vector3 randomDirection = Quaternion.Euler(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(0, 360), 0) * Vector3.up;

            // Apply the force to the Rigidbody
            food.GetComponent<Rigidbody>().AddForce(randomDirection * randomForce, ForceMode.Impulse);
            return;
        }

        onWishFulfilledEvent?.Invoke(this, EventArgs.Empty);
        contactPointCollider.isTrigger = false;
        delivered.Increment();
        combo.Increment();
        food.OnDelivery();
        audioSource.Play();
    }
}