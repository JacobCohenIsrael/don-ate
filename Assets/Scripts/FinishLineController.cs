using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finish Line Reached", gameObject);
    }
}
