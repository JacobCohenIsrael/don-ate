using System.Collections;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform[] spawnTransforms;
    [SerializeField] private bool isSpawning = true;
    [SerializeField] private VehicleMovementController nagmashPrefab;
    [SerializeField] private DifficultyManager difficultyManager;
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
            yield return new WaitForSeconds(spawnInterval);

        }
    }

}
