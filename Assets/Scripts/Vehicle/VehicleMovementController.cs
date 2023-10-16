using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource accelerationSound;
    [SerializeField] private DifficultyManager difficultyManager;

    private void Start()
    {
        rb.velocity = Vector3.forward * difficultyManager.VehicleSpeed;
        StartCoroutine(Accelerate());
    }

    private IEnumerator Accelerate()
    {
        yield return new WaitForSeconds(difficultyManager.AccelerationDelay);
        accelerationSound.Play();
        while (rb.velocity.magnitude < 15f)
        {
            rb.AddForce(Vector3.forward * difficultyManager.VehicleSpeed * 10000f);
            yield return new WaitForSeconds(0.15f);
        }
        accelerationSound.Stop();
    }
}
