using UnityEngine;

public class DestroyAfterSec : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy;

    private void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}
