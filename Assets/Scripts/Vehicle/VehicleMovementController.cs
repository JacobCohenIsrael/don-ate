using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private AudioSource accelerationSound;
    [SerializeField] private float secondsToAccelerate = 15f;

    private void Start()
    {
        rb.velocity = Vector3.forward * forwardSpeed;
        StartCoroutine(Accelerate());
    }

    private IEnumerator Accelerate()
    {
        yield return new WaitForSeconds(secondsToAccelerate);
        accelerationSound.Play();
        while (rb.velocity.magnitude < 15f)
        {
            rb.AddForce(Vector3.forward * forwardSpeed * 10000f);
            yield return new WaitForSeconds(0.15f);
        }
        accelerationSound.Stop();
    }
}
