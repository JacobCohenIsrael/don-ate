using UnityEngine;

public class ContactPointController : MonoBehaviour
{
    [SerializeField] private Counter delivered;
    [SerializeField] private Counter combo;

    // [SerializeField] private AudioClip _clip;
    private AudioSource audioSource;

    void Start() {
                audioSource = GetComponent<AudioSource>();

         if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var food = other.gameObject.GetComponent<FoodController>();
        if (food == null) return;

        delivered.Increment();
        combo.Increment();
        food.OnDelivery();
        audioSource.Play();


    }
}
