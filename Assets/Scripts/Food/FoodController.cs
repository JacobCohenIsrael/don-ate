using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodController : MonoBehaviour
{
    public FoodData foodData;
    [SerializeField] private float secondsToDecay = 5.0f;
    [SerializeField] private AudioClip[] collisionAudioClips;
    [SerializeField] private AudioSource collisionAudioSource;
    
    private Coroutine coroutineReference;


    private void Start()
    {
        coroutineReference = StartCoroutine(OnDecay());
    }

    private IEnumerator OnDecay()
    {
        yield return new WaitForSeconds(secondsToDecay);
        Destroy(gameObject);
    }

    public void OnDelivery()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (coroutineReference != null)
        {
            StopCoroutine(coroutineReference);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var collisionAudioClip = collisionAudioClips[Random.Range(0, collisionAudioClips.Length)];
        collisionAudioSource.clip = collisionAudioClip;
        collisionAudioSource.Play();
    }
}
