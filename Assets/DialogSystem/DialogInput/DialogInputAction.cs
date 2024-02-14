//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/DemoViglu/DialogSystem/DialogInput/DialogInputAction.inputactions
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

public partial class @DialogInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DialogInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DialogInputAction"",
    ""maps"": [
        {
            ""name"": ""DialogSystem"",
            ""id"": ""a91a4608-3a77-49b4-9c63-c4993c762a1c"",
            ""actions"": [
                {
                    ""name"": ""PassFunction"",
                    ""type"": ""Button"",
                    ""id"": ""7d7f2c6d-9954-45f3-8dcc-3761c9979ab3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93e007ed-7264-4f56-a59d-0c4a12359186"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PassFunction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95111977-2c5c-4566-a0bb-09cddb96661e"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PassFunction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2842b184-24ee-4307-805d-f7a100d46408"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PassFunction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DialogSystem
        m_DialogSystem = asset.FindActionMap("DialogSystem", throwIfNotFound: true);
        m_DialogSystem_PassFunction = m_DialogSystem.FindAction("PassFunction", throwIfNotFound: true);
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

    // DialogSystem
    private readonly InputActionMap m_DialogSystem;
    private List<IDialogSystemActions> m_DialogSystemActionsCallbackInterfaces = new List<IDialogSystemActions>();
    private readonly InputAction m_DialogSystem_PassFunction;
    public struct DialogSystemActions
    {
        private @DialogInputAction m_Wrapper;
        public DialogSystemActions(@DialogInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @PassFunction => m_Wrapper.m_DialogSystem_PassFunction;
        public InputActionMap Get() { return m_Wrapper.m_DialogSystem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogSystemActions set) { return set.Get(); }
        public void AddCallbacks(IDialogSystemActions instance)
        {
            if (instance == null || m_Wrapper.m_DialogSystemActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DialogSystemActionsCallbackInterfaces.Add(instance);
            @PassFunction.started += instance.OnPassFunction;
            @PassFunction.performed += instance.OnPassFunction;
            @PassFunction.canceled += instance.OnPassFunction;
        }

        private void UnregisterCallbacks(IDialogSystemActions instance)
        {
            @PassFunction.started -= instance.OnPassFunction;
            @PassFunction.performed -= instance.OnPassFunction;
            @PassFunction.canceled -= instance.OnPassFunction;
        }

        public void RemoveCallbacks(IDialogSystemActions instance)
        {
            if (m_Wrapper.m_DialogSystemActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDialogSystemActions instance)
        {
            foreach (var item in m_Wrapper.m_DialogSystemActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DialogSystemActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DialogSystemActions @DialogSystem => new DialogSystemActions(this);
    public interface IDialogSystemActions
    {
        void OnPassFunction(InputAction.CallbackContext context);
    }
}
