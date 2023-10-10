using UnityEngine;

public class ContactPointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("FOOOOOOOOOOOD!!!", gameObject);
    }
}
