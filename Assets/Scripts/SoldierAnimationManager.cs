using System;
using UnityEngine;

public class SoldierAnimationManager : MonoBehaviour
{
    [SerializeField] private ContactPointController contactPointController;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (contactPointController == null) return;
        contactPointController.onWishFulfilledEvent += OnWishFulfilled;
    }
    public void OnWishFulfilled(object sender, EventArgs e)
    {
        animator.SetTrigger("Salute");
    }

    private void OnDestroy()
    {
        if (contactPointController == null) return;
        contactPointController.onWishFulfilledEvent -= OnWishFulfilled;
    }
   

}
