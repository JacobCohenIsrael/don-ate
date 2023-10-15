using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    [SerializeField] private GameEvent comboStreakEvent;

    [SerializeField] private GameObject[] crowdPrefabs;

    [SerializeField] private Transform[] crowdTransforms;
    private void Awake()
    {
        comboStreakEvent.RegisterListener(OnComboStreak);
    }

    private void OnDestroy()
    {
        comboStreakEvent.UnregisterListener(OnComboStreak);
    }

    private void OnComboStreak()
    {
        int random1 = Random.Range(0, crowdTransforms.Length);
        int random2 = Random.Range(0, crowdPrefabs.Length);
        var randomTransform = crowdTransforms[random1];
        var rotation = random1 > 3 ? Quaternion.Euler(0,-90,0) : Quaternion.Euler(0, 90, 0);
        var randomPositionOffset = Random.onUnitSphere * 1.5f;
        randomPositionOffset.y = 0;

        Instantiate(crowdPrefabs[random2], randomTransform.position + randomPositionOffset, rotation);
    }
}
