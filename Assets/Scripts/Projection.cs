using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene simulationScene;
    private PhysicsScene physicsScene;
    private Rigidbody ghostProjectileRB;

    [SerializeField] private GameObject ghostProjectile;
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
        Debug.Log("Hello");
        ghostProjectile.transform.position = position;
        ghostProjectileRB.velocity = Vector3.zero;

        ghostProjectile.GetComponent<FoodController>().Throw(force * 1.1f, layer);

        line.positionCount = maxPhysicsFrameIteration;

        for (int i = 0; i < maxPhysicsFrameIteration; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
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
