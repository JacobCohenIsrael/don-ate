using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] FoodController projectile;
    [SerializeField] Transform cannon;
    [SerializeField] TimeScale forceGauge;
    [SerializeField] LayerMask layer;

    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float maxHoldTime;

    [SerializeField] private GameEventArg foodChangedEvent;

    private float mouseWasLastPressed;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            var spawnedProjectile = Instantiate(projectile, cannon.position, cannon.rotation);
            Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
            
            Vector3 targetPosition = hit.point;
            Vector3 direction = targetPosition - cannon.position;

            projectileRigidBody.AddForce(transform.up.normalized * force / 2, ForceMode.VelocityChange);
            projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);
        }
    }
    
    private void OnFoodChange(object foodPrefab)
    {
        projectile = (FoodController)foodPrefab;
    }
}
