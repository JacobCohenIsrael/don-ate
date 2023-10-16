using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform[] spawnTransforms;
    [SerializeField] private bool isSpawning = true;
    [SerializeField] private GameObject nagmash;
    [SerializeField] private GameEvent gameOverEvent;

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

    public void OnGameOver()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        gameOverEvent.UnregisterListener(OnGameOver);
    }

}
