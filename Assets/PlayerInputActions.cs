//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Throw"",
            ""id"": ""5553a7d4-49c6-4942-8056-e6c461c10ef9"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""568b8d71-461f-4c7a-a51e-ad8a316afada"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0f388eb-8739-4c4a-9dcd-f4d0a5e96567"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""698e3614-c4c8-40a9-8a1d-6804c1154c1b"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Throw
        m_Throw = asset.FindActionMap("Throw", throwIfNotFound: true);
        m_Throw_Tap = m_Throw.FindAction("Tap", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Throw
    private readonly InputActionMap m_Throw;
    private List<IThrowActions> m_ThrowActionsCallbackInterfaces = new List<IThrowActions>();
    private readonly InputAction m_Throw_Tap;
    public struct ThrowActions
    {
        private @PlayerInputActions m_Wrapper;
        public ThrowActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Throw_Tap;
        public InputActionMap Get() { return m_Wrapper.m_Throw; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThrowActions set) { return set.Get(); }
        public void AddCallbacks(IThrowActions instance)
        {
            if (instance == null || m_Wrapper.m_ThrowActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ThrowActionsCallbackInterfaces.Add(instance);
            @Tap.started += instance.OnTap;
            @Tap.performed += instance.OnTap;
            @Tap.canceled += instance.OnTap;
        }

        private void UnregisterCallbacks(IThrowActions instance)
        {
            @Tap.started -= instance.OnTap;
            @Tap.performed -= instance.OnTap;
            @Tap.canceled -= instance.OnTap;
        }

        public void RemoveCallbacks(IThrowActions instance)
        {
            if (m_Wrapper.m_ThrowActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IThrowActions instance)
        {
            foreach (var item in m_Wrapper.m_ThrowActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ThrowActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ThrowActions @Throw => new ThrowActions(this);
    public interface IThrowActions
    {
        void OnTap(InputAction.CallbackContext context);
    }
}
