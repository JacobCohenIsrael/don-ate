using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrowdSpawner : MonoBehaviour
{
    [SerializeField] private GameEvent comboStreakEvent;

    [SerializeField] private GameObject crowdPrefab;

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
        var randomTransform = crowdTransforms[Random.Range(0, crowdTransforms.Length)];
        Instantiate(crowdPrefab, randomTransform.position, Quaternion.identity);
    }
}
