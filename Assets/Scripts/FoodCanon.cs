using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCanon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform canon;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            float throwForce = 10f;
            Fire(throwForce); 
        }
    }

    void Fire(float force)
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
