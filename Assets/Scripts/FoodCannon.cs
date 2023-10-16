using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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
    [SerializeField] private GameEvent gameOverEvent;


    private RaycastHit hit;

    private bool isValidTarget;

    private bool hasStarted;

    private IEnumerator EnableThrow()
    {
        yield return new WaitForSeconds(3.0f);
        hasStarted = true;
    }

    private void Awake()
    {
        StartCoroutine(EnableThrow());
        foodChangedEvent.RegisterListener(OnFoodChange);
        gameOverEvent.RegisterListener(OnGameOver);
        forceGauge.SetMaxDuration(maxHoldTime);
    }

    private void OnDestroy()
    {
        foodChangedEvent.UnregisterListener(OnFoodChange);
        gameOverEvent.UnregisterListener(OnGameOver);
    }

    private void Update()
    {
        if (!hasStarted) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            PrepareToThrow();
        }
        if (Input.GetMouseButtonUp(0) && isValidTarget)
        {
            float force = forceGauge.Value * (maxForce - minForce) + minForce;
            var spawnedProjectile = Instantiate(projectile.gameObject, cannon.position, cannon.rotation);
            Throw(spawnedProjectile, force, false);
            forceGauge.Stop();
            projection.Reset();
        }

        if (Input.GetMouseButton(0) && isValidTarget)
        {
            float force = forceGauge.Value * (maxForce - minForce) + minForce;
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

    public void Throw(GameObject projectile, float force, bool isSimulation)
    {
        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();

        Vector3 targetPosition = hit.point;
        Vector3 direction = targetPosition - cannon.position;

        projectileRigidBody.AddForce(transform.up.normalized * force / 2, ForceMode.VelocityChange);
        projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);

        if (!isSimulation)
        {
            foodThrownEvent.Raise();
        }
    }

    public void OnGameOver()
    {
        this.gameObject.SetActive(false);
    }
    private void OnFoodChange(object foodPrefab)
    {
        projectile = (FoodController)foodPrefab;
    }
}
