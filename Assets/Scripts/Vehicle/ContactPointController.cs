using UnityEngine;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;
    
    private void OnTriggerEnter(Collider other)
    {
        var food = other.gameObject.GetComponent<FoodController>();
        if (food == null) return;
        
        delivered.Increment();
        combo.Increment();
        food.OnDelivery();
    }
}
