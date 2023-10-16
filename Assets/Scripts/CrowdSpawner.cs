using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    [SerializeField] private GameEvent comboStreakEvent;

    [SerializeField] private GameObject[] crowdPrefabs;

    [SerializeField] private Transform[] crowdTransformsLeft;
    [SerializeField] private Transform[] crowdTransformsRight;
    [SerializeField] private int initialCrowd = 12;

    private int totalCrowdTransformsCount;

    private void Awake()
    {
        comboStreakEvent.RegisterListener(OnComboStreak);
        totalCrowdTransformsCount = crowdTransformsLeft.Length + crowdTransformsRight.Length;
    }

    private void Start()
    {
        for(int i =0; i < initialCrowd; i++)
        {
            SpawnRandomCrowd();
        }
    }

    private void OnDestroy()
    {
        comboStreakEvent.UnregisterListener(OnComboStreak);
    }

    private void OnComboStreak()
    {
        SpawnRandomCrowd();
        SpawnRandomCrowd();
    }

    private void SpawnRandomCrowd()
    {
        int randomTransformIndex = Random.Range(0, totalCrowdTransformsCount);
        int randomPrefabIndex = Random.Range(0, crowdPrefabs.Length);
        bool isTransformLeftSide = randomTransformIndex < crowdTransformsLeft.Length;

        var randomTransform = isTransformLeftSide ? crowdTransformsLeft[randomTransformIndex] : crowdTransformsRight[randomTransformIndex % crowdTransformsLeft.Length];
        var rotation = isTransformLeftSide ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, -90, 0);

        var randomPositionOffset = Random.onUnitSphere * 0.4f;
        randomPositionOffset.z *= 5;
        randomPositionOffset.y = 0;

        Instantiate(crowdPrefabs[randomPrefabIndex], randomTransform.position + randomPositionOffset, rotation);
    }
}
