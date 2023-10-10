using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardSpeed;

    private void Start()
    {
        rb.velocity = Vector3.forward * forwardSpeed;
    }
}
