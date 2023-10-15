using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private FoodData[] foodDataArray;
    [SerializeField] private CapsuleCollider contactPointCollider;

    [FormerlySerializedAs("wishlistUI")] [SerializeField] private FoodWishlistUI foodWishlistUI;
    [SerializeField] private Transform layout;
    public event EventHandler OnWishFulfilledEvent;

    private List<FoodData> wishlist = new();
    
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            var foodData = foodDataArray[UnityEngine.Random.Range(0, foodDataArray.Length)];
            wishlist.Add(foodData);
        }

        populateLayout();
    }

    private void populateLayout()
    {
        // Iterate through all the children of the parent GameObject
        foreach (Transform child in layout.transform)
        {
            // Destroy the child GameObject
            Destroy(child.gameObject);
        }

        // After destroying all the children, clear the parent's child list
        layout.transform.DetachChildren();
        
        wishlist.ForEach(wish =>
        {
            var item = Instantiate(foodWishlistUI, layout);
            item.Init(wish);
            item.gameObject.SetActive(true);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        var food = other.gameObject.GetComponent<FoodController>();
        if (food == null) return;

        var foundWish = wishlist.Find(wish => wish == food.foodData);
        if (foundWish == null)
        {
            // Calculate a random force within the specified range
            float randomForce = UnityEngine.Random.Range(5, 20);

            // Generate a random direction with some divergence
            Vector3 randomDirection = Quaternion.Euler(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(0, 360), 0) * Vector3.up;

            // Apply the force to the Rigidbody
            food.GetComponent<Rigidbody>().AddForce(randomDirection * randomForce, ForceMode.Impulse);
            return;
        }

        wishlist.Remove(foundWish);
        populateLayout();

        if (wishlist.Count > 0)
        {
            delivered.Increment();
        }
        else
        {
            combo.Increment();
            OnWishFulfilledEvent?.Invoke(this, EventArgs.Empty);
            contactPointCollider.isTrigger = false;
        }
        food.OnDelivery();
        audioSource.Play();
    }
}