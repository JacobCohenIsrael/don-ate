using System;
using UnityEngine;

public class SoldierAnimationManager : MonoBehaviour
{
    [SerializeField] private ContactPointController contactPointController;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        contactPointController.onWishFulfilledEvent += OnWishFulfilled;
    }
    public void OnWishFulfilled(object sender, EventArgs e)
    {
        Vector3 oldPosition = this.transform.position;
        animator.SetTrigger("Salute");
        this.transform.position = new Vector3(oldPosition.x, oldPosition.y - 0.5f, oldPosition.z);
    }

    private void OnDestroy()
    {
        contactPointController.onWishFulfilledEvent -= OnWishFulfilled;
    }
   

}
