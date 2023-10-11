using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCanon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform canon;
    [SerializeField] TimeScale forceGauge;
    [SerializeField] LayerMask layer;

    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float maxHoldTime;

    private float mouseWasLastPressed;

    private void Awake()
    {
        forceGauge.SetMaxDuration(maxHoldTime);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            forceGauge.Start();
        }
        if (Input.GetMouseButtonUp(0))
        {
            float force = forceGauge.Value * (maxForce - minForce) + minForce;
            Throw(force);

            forceGauge.Stop();
        }



    }

    void Throw(float force)
    {
        GameObject spawnedProjectile = Instantiate(projectile, canon.position, canon.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = targetPosition - canon.position;

            projectileRigidBody.AddForce(transform.up.normalized * force / 2, ForceMode.VelocityChange);
            projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);
        }
    }
}
