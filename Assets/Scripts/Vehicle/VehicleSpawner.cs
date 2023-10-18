using System.Collections;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform[] spawnTransforms;
    [SerializeField] private bool isSpawning = true;

    [SerializeField] private GameEvent gameOverEvent;
    [SerializeField] private VehicleMovementController nagmashPrefab;
    [SerializeField] private DifficultyManager difficultyManager;

    private void Awake()
    {
        gameOverEvent.RegisterListener(OnGameOver);
    }

    void Start()
    {
        StartCoroutine(SpawnForever());
    }

    void SpawnNagmash()
    {
        var spawnTransform = spawnTransforms[Random.Range(0, Mathf.Min(difficultyManager.NumberOfLanes, spawnTransforms.Length))];
        Instantiate(nagmashPrefab, spawnTransform.position, Quaternion.identity);
    }

    private IEnumerator SpawnForever()
    {
        while (isSpawning)
        {
            SpawnNagmash();
            yield return new WaitForSeconds(difficultyManager.VehicleSpawnRate);
        }
    }

    public void OnGameOver()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        gameOverEvent.UnregisterListener(OnGameOver);
    }

}
