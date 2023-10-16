using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameSoundManager : MonoBehaviour
{
    [SerializeField] private GameEvent foodThrownEvent;
    [SerializeField] private GameEvent comboStreakEvent;
    
    [SerializeField] private AudioClip[] throwSounds;
    [SerializeField] private AudioSource throwAudioSource;

    [SerializeField] private Counter combo;
    [SerializeField] private AudioClip[] comboSounds;
    [SerializeField] private AudioSource comboAudioSource;
    [SerializeField] private AudioSource cheerAudioSource;
    
    private void Awake()
    {
        combo.OnChange += OnComboChange;
        foodThrownEvent.RegisterListener(OnFoodThrown);
        comboStreakEvent.RegisterListener(OnComboStreak);
    }

    private void OnDestroy()
    {
        combo.OnChange -= OnComboChange;
        foodThrownEvent.UnregisterListener(OnFoodThrown);
        comboStreakEvent.UnregisterListener(OnComboStreak);
    }

    private void OnComboStreak()
    {
        PlayRandomSound(comboSounds, comboAudioSource);
    }

    private void OnFoodThrown()
    {
        PlayRandomSound(throwSounds, throwAudioSource);
    }

    private void PlayRandomSound(AudioClip[] audioClips, AudioSource audioSource)
    {
        var audioClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    
    private void OnComboChange(object sender, EventArgs e)
    {
        if (combo.Value == 5)
        {
            cheerAudioSource.Play();
        }
    }
}
