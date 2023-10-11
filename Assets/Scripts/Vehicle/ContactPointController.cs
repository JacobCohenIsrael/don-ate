using UnityEngine;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;
    
    private void OnTriggerEnter(Collider other)
    {
        delivered.Increment();
        combo.Increment();
        
        Destroy(other.gameObject);
    }
}
