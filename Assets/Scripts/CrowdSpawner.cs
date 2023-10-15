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
        int random = Random.Range(0, crowdTransforms.Length);
        var randomTransform = crowdTransforms[random];
        var randomPositionOffset = Random.onUnitSphere * 1.5f;
        randomPositionOffset.y = 0;

        Instantiate(crowdPrefabs[(random + 3) % crowdPrefabs.Length], randomTransform.position + randomPositionOffset, Quaternion.identity);

        

    }
}
