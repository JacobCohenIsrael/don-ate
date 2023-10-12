using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    [SerializeField] private GameEvent foodThrownEvent;
    [SerializeField] private GameEvent comboStreakEvent;
    
    [SerializeField] private AudioClip[] throwSounds;
    [SerializeField] private AudioClip[] comboSounds;
    [SerializeField] private AudioSource audioSource;

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
        PlayRandomSound(comboSounds);
    }

    private void OnFoodThrown()
    {
        PlayRandomSound(throwSounds);
    }

    private void PlayRandomSound(AudioClip[] audioClips)
    {
        var audioClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
