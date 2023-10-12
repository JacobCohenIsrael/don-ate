using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform canon;
    [SerializeField] TimeScale forceGauge;
    [SerializeField] LayerMask layer;
    [SerializeField] Projection projection;

    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float maxHoldTime;

    private void Awake()
    {
        forceGauge.SetMaxDuration(maxHoldTime);
    }

    private void Update()
    {
        float force = forceGauge.Value * (maxForce - minForce) + minForce;

        if (Input.GetMouseButtonDown(0))
        {
            forceGauge.Start();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject spawnedProjectile = Instantiate(projectile, canon.position, canon.rotation);
            spawnedProjectile.GetComponent<FoodController>().Throw(force, layer);
            forceGauge.Stop();
            projection.Reset();
        }

        if(Input.GetMouseButton(0))
        {
            projection.SimulateTrajectory(canon.position, force, layer);
        }

    }
}
