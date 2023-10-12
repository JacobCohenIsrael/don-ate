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

    public void Throw(float force, int layer)
    {
        Rigidbody projectileRigidBody = this.GetComponent<Rigidbody>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = targetPosition - this.transform.position;

            projectileRigidBody.AddForce(transform.up.normalized * force / 2, ForceMode.VelocityChange);
            projectileRigidBody.AddForce(direction.normalized * force, ForceMode.VelocityChange);
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
