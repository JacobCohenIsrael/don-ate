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

    private RaycastHit hit;

    private bool isValidTarget;

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
            PrepareToThrow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            float force = forceGauge.Value * (maxForce - minForce) + minForce;
            Throw(force);
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

    void Throw(float force)
    {
        if (!isValidTarget) return;
        
        var spawnedProjectile = Instantiate(projectile, cannon.position, cannon.rotation);
        Rigidbody projectileRigidBody = spawnedProjectile.GetComponent<Rigidbody>();
            
        Vector3 targetPosition = hit.point;
        Vector3 direction = targetPosition - cannon.position;

        projectileRigidBody.AddForce(transform.up.normalized * force / 2, ForceMode.VelocityChange);
        projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);
        
        forceGauge.Stop();
    }
    
    private void OnFoodChange(object foodPrefab)
    {
        projectile = (FoodController)foodPrefab;
    }
}
