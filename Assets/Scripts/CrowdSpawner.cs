using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
        Instantiate(crowdPrefabs[(random + 3) % crowdPrefabs.Length], randomTransform.position, Quaternion.identity);
    }
}
