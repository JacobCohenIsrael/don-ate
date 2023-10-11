using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform[] spawnTransforms;
    [SerializeField] private bool isSpawning = true;
    [SerializeField] private GameObject nagmash;
    void Start()
    {
        StartCoroutine(SpawnForever());
    }

    void SpawnNagmash()
    {
        var spawnTransform = spawnTransforms[Random.Range(0, spawnTransforms.Length)];
        Instantiate(nagmash, spawnTransform.position, Quaternion.identity);
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
