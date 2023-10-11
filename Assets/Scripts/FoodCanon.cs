using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCanon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform canon;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float maxHoldTime;

    private float mouseWasLastPressed;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseWasLastPressed = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdTime = Time.time - mouseWasLastPressed;
            float force = minForce + Mathf.Min(1, holdTime / maxHoldTime) * (maxForce - minForce);

            Throw(force);
        }

    }

    void Throw(float force)
    {
        GameObject spawnedProjectile = Instantiate(projectile, canon.position, canon.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = targetPosition - canon.position;

            projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);
        }
    }
}
