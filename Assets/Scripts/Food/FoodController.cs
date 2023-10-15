using System.Collections;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public FoodData foodData;
    [SerializeField] private float secondsToDecay = 5.0f;
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
}
