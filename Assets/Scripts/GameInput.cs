using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField] private GameEvent onTapPerformedEvent;
    [SerializeField] private GameEvent onTapCanceledEvent;
    
    private PlayerInputActions playerInputActions;

    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        StartCoroutine(EnableThrow());
    }

    private IEnumerator EnableThrow()
    {
        yield return new WaitForSeconds(3.0f);
        playerInputActions.Throw.Enable();
    }

    private void Start()
    {
        playerInputActions.Throw.Tap.performed += OnTapPerformed;
        playerInputActions.Throw.Tap.canceled += OnTapCanceled;
    }

    private void OnDestroy()
    {
        playerInputActions.Throw.Tap.performed -= OnTapPerformed;
        playerInputActions.Throw.Tap.canceled -= OnTapCanceled;
    }

    private void OnTapPerformed(InputAction.CallbackContext obj)
    {
        onTapPerformedEvent.Raise();
    }

    private void OnTapCanceled(InputAction.CallbackContext obj)
    {
        onTapCanceledEvent.Raise();
    }
}
