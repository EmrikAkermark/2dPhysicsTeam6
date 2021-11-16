// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/HelperClasses/New Input System/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player 1"",
            ""id"": ""f705ba1b-968a-46b4-80eb-3b3822741778"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0cd7756f-cbc9-4d81-85a8-082a55572dd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""72582a0c-9211-4bb1-9156-b4de3ead6f78"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""a444cf68-5627-4654-9a80-21d4bf00b729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""5de28fd0-0ada-43de-bc6a-13a182bd6f64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mass Change"",
                    ""type"": ""Button"",
                    ""id"": ""07d2e8dc-9885-46b4-92e5-fbd8d2a7531b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98d5177b-fa65-46c8-a4a3-07f1b2891b97"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""299e243a-0dbd-47f2-b289-55f725297a16"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""26d249c4-b8c3-4bb2-bcd2-bb6965e3f1be"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f3596e28-6cce-4e49-b58f-af2b4793da7d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b9b04bf5-7e03-4380-ba6a-0a4b83827cbe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ec44c37-f61d-4972-b77f-eee59eea8efe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c2542e26-b80b-4167-8938-fbc1e47ebc1f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c6e767d-f854-4793-9793-338bc6ea0f92"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53563562-2de8-4be6-8e5e-730b3ade54d7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mass Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player 2"",
            ""id"": ""7db39fbd-d5ad-4cd1-bc4e-b5e08154fdfa"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a3154332-21b3-4294-ad0b-edb647050b6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""13a8cc12-9847-4fd0-995f-02dc21bf11b0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""dda3a91d-18bb-4eae-adf4-7ec264bbd536"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""c2d86a2f-6ae2-4669-8e99-0f646a458927"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mass Change"",
                    ""type"": ""Button"",
                    ""id"": ""bb470dfa-d212-4936-97b1-b46d9e6ab9b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0cc9b4c8-7b17-49e8-9014-39ab0c4139e4"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""0ece28f7-cd0d-42b2-9c0b-7695d559efd3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e8d2bbc8-affb-4b5d-889a-7f533509ffb8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1dfa3082-91b0-4c52-99c0-a7f2efc094f8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c999c8ea-a402-4c86-a3c2-4a36746aec28"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0a95e054-2823-4312-a590-f5cc42d19ddc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""194f46e2-0a90-4ebf-9c08-979e5736b2f6"",
                    ""path"": ""<Keyboard>/numpadPeriod"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0215acc3-36b0-4287-9805-6846454b43e7"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a812251d-1e6e-47e7-bb3f-e59ce8eb66a2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mass Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player 1
        m_Player1 = asset.FindActionMap("Player 1", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Movement = m_Player1.FindAction("Movement", throwIfNotFound: true);
        m_Player1_Shoot = m_Player1.FindAction("Shoot", throwIfNotFound: true);
        m_Player1_Dash = m_Player1.FindAction("Dash", throwIfNotFound: true);
        m_Player1_MassChange = m_Player1.FindAction("Mass Change", throwIfNotFound: true);
        // Player 2
        m_Player2 = asset.FindActionMap("Player 2", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_Movement = m_Player2.FindAction("Movement", throwIfNotFound: true);
        m_Player2_Shoot = m_Player2.FindAction("Shoot", throwIfNotFound: true);
        m_Player2_Dash = m_Player2.FindAction("Dash", throwIfNotFound: true);
        m_Player2_MassChange = m_Player2.FindAction("Mass Change", throwIfNotFound: true);
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

    // Player 1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Movement;
    private readonly InputAction m_Player1_Shoot;
    private readonly InputAction m_Player1_Dash;
    private readonly InputAction m_Player1_MassChange;
    public struct Player1Actions
    {
        private @InputMaster m_Wrapper;
        public Player1Actions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Movement => m_Wrapper.m_Player1_Movement;
        public InputAction @Shoot => m_Wrapper.m_Player1_Shoot;
        public InputAction @Dash => m_Wrapper.m_Player1_Dash;
        public InputAction @MassChange => m_Wrapper.m_Player1_MassChange;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnShoot;
                @Dash.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDash;
                @MassChange.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMassChange;
                @MassChange.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMassChange;
                @MassChange.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMassChange;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @MassChange.started += instance.OnMassChange;
                @MassChange.performed += instance.OnMassChange;
                @MassChange.canceled += instance.OnMassChange;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player 2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_Movement;
    private readonly InputAction m_Player2_Shoot;
    private readonly InputAction m_Player2_Dash;
    private readonly InputAction m_Player2_MassChange;
    public struct Player2Actions
    {
        private @InputMaster m_Wrapper;
        public Player2Actions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @Movement => m_Wrapper.m_Player2_Movement;
        public InputAction @Shoot => m_Wrapper.m_Player2_Shoot;
        public InputAction @Dash => m_Wrapper.m_Player2_Dash;
        public InputAction @MassChange => m_Wrapper.m_Player2_MassChange;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnShoot;
                @Dash.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDash;
                @MassChange.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMassChange;
                @MassChange.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMassChange;
                @MassChange.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMassChange;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @MassChange.started += instance.OnMassChange;
                @MassChange.performed += instance.OnMassChange;
                @MassChange.canceled += instance.OnMassChange;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    public interface IPlayer1Actions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMassChange(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMassChange(InputAction.CallbackContext context);
    }
}
