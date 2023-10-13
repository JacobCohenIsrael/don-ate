using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    [SerializeField] private GameEvent foodThrownEvent;
    [SerializeField] private GameEvent comboStreakEvent;
    
    [SerializeField] private AudioClip[] throwSounds;
    [SerializeField] private AudioSource throwAudioSource;
    
    [SerializeField] private AudioClip[] comboSounds;
    [SerializeField] private AudioSource comboAudioSource;

    private void Awake()
    {
        foodThrownEvent.RegisterListener(OnFoodThrown);
        comboStreakEvent.RegisterListener(OnComboStreak);
    }

    private void OnDestroy()
    {
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
}
