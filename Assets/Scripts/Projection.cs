using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene physicsScene;
    private Rigidbody ghostProjectileRB;

    [SerializeField] private GameObject ghostProjectile;
    [SerializeField] private FoodCannon cannon;
    [SerializeField] private LineRenderer line;
    [SerializeField] private int maxPhysicsFrameIteration;

    private void Start()
    {
        CreatePhysicsScene();
        SceneManager.MoveGameObjectToScene(ghostProjectile.gameObject, simulationScene);
        ghostProjectileRB = ghostProjectile.GetComponent<Rigidbody>();
    }
    void CreatePhysicsScene()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

    }

    public void SimulateTrajectory(Vector3 position, float force, int layer)
    {
        ghostProjectile.transform.position = position;
        ghostProjectileRB.velocity = Vector3.zero;

        cannon.Throw(ghostProjectile, force * 1.1f, true);

        line.positionCount = maxPhysicsFrameIteration;

        for (int i = 0; i < maxPhysicsFrameIteration; i++)
        {
            physicsScene.Simulate(5 * Time.fixedDeltaTime);
            line.SetPosition(i, ghostProjectile.transform.position);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < maxPhysicsFrameIteration; i++)
        {
            line.SetPosition(i, Vector3.zero);
        }
    }
}
