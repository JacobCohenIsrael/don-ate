using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        transform.position = Vector3.Lerp(transform.position, worldMousePosition, Time.deltaTime * moveSpeed);
    }
}
