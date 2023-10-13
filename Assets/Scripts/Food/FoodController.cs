using System.Collections;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private Counter combo;
    [SerializeField] private float secondsToDecay = 5.0f;
    private Coroutine coroutineReference;


    private void Start()
    {
        coroutineReference = StartCoroutine(OnDecay());
    }

    private IEnumerator OnDecay()
    {
        yield return new WaitForSeconds(secondsToDecay);
        if(secondsToDecay > 0)
        {
            combo.Decrement();
            Destroy(gameObject);
        }
    }

    public void OnDelivery()
    {
        if(secondsToDecay > 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {        
        if (coroutineReference != null)
        {
            StopCoroutine(coroutineReference);
        }
    }
}
