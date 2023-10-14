using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] FoodController projectile;
    [SerializeField] Transform cannon;
    [SerializeField] TimeScale forceGauge;
    [SerializeField] LayerMask layer;
    [SerializeField] Projection projection;

    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float maxHoldTime;

    [SerializeField] private GameEventArg foodChangedEvent;
    [SerializeField] private GameEvent foodThrownEvent;

    private RaycastHit hit;

    private bool isValidTarget;

    private void Awake()
    {
        foodChangedEvent.RegisterListener(OnFoodChange);
        forceGauge.SetMaxDuration(maxHoldTime);
    }

    private void OnDestroy()
    {
        foodChangedEvent.UnregisterListener(OnFoodChange);
    }

    private void Update()
    {
        float force = forceGauge.Value * (maxForce - minForce) + minForce;

        if (Input.GetMouseButtonDown(0))
        {
            PrepareToThrow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isValidTarget)
            {
                var spawnedProjectile = Instantiate(projectile.gameObject, cannon.position, cannon.rotation);
                Throw(spawnedProjectile, force);
                forceGauge.Stop();
                projection.Reset();
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (!isValidTarget) return;
            projection.SimulateTrajectory(cannon.position, force, layer);
        }

    }

    private void PrepareToThrow()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            isValidTarget = true;
            forceGauge.Start();
        }
        else
        {
            isValidTarget = false;
        }
    }

    public void Throw(GameObject projectile, float force)
    {
        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();

        Vector3 targetPosition = hit.point;
        Vector3 direction = targetPosition - cannon.position;

        projectileRigidBody.AddForce(transform.up.normalized * force / 2, ForceMode.VelocityChange);
        projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);

        foodThrownEvent.Raise();
    }

    private void OnFoodChange(object foodPrefab)
    {
        projectile = (FoodController)foodPrefab;
    }
}
