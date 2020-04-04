// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Input/Input_Default.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input_Default : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input_Default()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input_Default"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""23d7806f-8f93-487c-8c31-481379dbff01"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a003fef-4305-44de-8443-bb4ec1f6ffed"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""PassThrough"",
                    ""id"": ""05c9e436-2839-4117-9393-69ae15fd9aa0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""a8cb7822-2e5b-4a11-9909-e541d70b8c69"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""11ec0b0d-ada5-4d05-9e7b-caa5912ac497"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""x56"",
                    ""id"": ""2f9b568d-cca8-459a-a9d4-1c705cc403ff"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b535d541-1167-4fcb-8ca8-93ce1ef548fb"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Throttle>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""logitech X56"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""21961242-7fdd-487f-ac5e-817834d12b81"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Throttle>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""logitech X56"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""xbox"",
                    ""id"": ""addba43b-7b01-47c5-ba83-963634ad1395"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""499461cb-509d-4e63-8e2d-f126918aa1f8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9e4c379d-6564-459f-aa49-b853a911c7b3"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keyboardAndmouse"",
                    ""id"": ""4b3c2338-6a76-4867-9aef-22a64b2ca3f0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a3aab2c6-1539-4261-b0b0-303daddd31f3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mouse and keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1b5bdb56-3c31-4696-9e89-a63e49832140"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mouse and keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""x56"",
                    ""id"": ""fff7da3d-6cef-4660-8080-fea2b8e9932a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1328c65d-829f-47e9-9f31-4edbb1ed2980"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Stick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": ""logitech X56"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4358ae97-d0a9-4397-bba2-171270ae0f7b"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Stick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": ""logitech X56"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c29b7b54-8020-4b7c-b702-1c598fb2a14a"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Stick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": ""logitech X56"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49ac1188-9efa-4c5f-b760-1e7f1a6cb01e"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Stick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": ""logitech X56"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""xbox"",
                    ""id"": ""649fb918-3631-463e-9e27-33f25239f67b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e1c43264-e439-4ff7-a36c-0c3541b71c38"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f44ee242-ef0a-4483-95ee-370806591b9a"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22fcb749-9fd0-42e0-8715-766f75b3cfbe"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""84d3b8c8-a683-417c-a390-2983b71f11ad"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""20df9f40-bd7c-4de4-9e27-bda12e3b9c18"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=0.3,y=0.3)"",
                    ""groups"": ""mouse and keyboard"",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec9aca85-e763-4948-8459-9bf304f5f724"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Stick>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""logitech X56"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78332544-b6ae-49db-aef7-ac96250b167f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb0e9397-8ed9-4603-811d-14c09f34730c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mouse and keyboard"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2962be4c-8ba6-4596-b703-fa8edf19b7a3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mouse and keyboard"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64fd24ec-0ba2-4593-bf5c-8cc5d97272d3"",
                    ""path"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Throttle>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""logitech X56"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa9e2601-ee02-4595-bcde-2e5676d463fe"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""xbox"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08cebf4e-5119-4ff0-bf64-7c731c9e9f54"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""mouse and keyboard"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""xbox"",
            ""bindingGroup"": ""xbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""mouse and keyboard"",
            ""bindingGroup"": ""mouse and keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""logitech X56"",
            ""bindingGroup"": ""logitech X56"",
            ""devices"": [
                {
                    ""devicePath"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Stick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<HID::Mad Catz Saitek Pro Flight X-56 Rhino Throttle>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Throttle = m_Player.FindAction("Throttle", throwIfNotFound: true);
        m_Player_LookAround = m_Player.FindAction("LookAround", throwIfNotFound: true);
        m_Player_Grapple = m_Player.FindAction("Grapple", throwIfNotFound: true);
        m_Player_jump = m_Player.FindAction("jump", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Throttle;
    private readonly InputAction m_Player_LookAround;
    private readonly InputAction m_Player_Grapple;
    private readonly InputAction m_Player_jump;
    public struct PlayerActions
    {
        private @Input_Default m_Wrapper;
        public PlayerActions(@Input_Default wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_Player_Throttle;
        public InputAction @LookAround => m_Wrapper.m_Player_LookAround;
        public InputAction @Grapple => m_Wrapper.m_Player_Grapple;
        public InputAction @jump => m_Wrapper.m_Player_jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottle;
                @LookAround.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookAround;
                @LookAround.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookAround;
                @LookAround.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookAround;
                @Grapple.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapple;
                @Grapple.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapple;
                @Grapple.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrapple;
                @jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @LookAround.started += instance.OnLookAround;
                @LookAround.performed += instance.OnLookAround;
                @LookAround.canceled += instance.OnLookAround;
                @Grapple.started += instance.OnGrapple;
                @Grapple.performed += instance.OnGrapple;
                @Grapple.canceled += instance.OnGrapple;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_xboxSchemeIndex = -1;
    public InputControlScheme xboxScheme
    {
        get
        {
            if (m_xboxSchemeIndex == -1) m_xboxSchemeIndex = asset.FindControlSchemeIndex("xbox");
            return asset.controlSchemes[m_xboxSchemeIndex];
        }
    }
    private int m_mouseandkeyboardSchemeIndex = -1;
    public InputControlScheme mouseandkeyboardScheme
    {
        get
        {
            if (m_mouseandkeyboardSchemeIndex == -1) m_mouseandkeyboardSchemeIndex = asset.FindControlSchemeIndex("mouse and keyboard");
            return asset.controlSchemes[m_mouseandkeyboardSchemeIndex];
        }
    }
    private int m_logitechX56SchemeIndex = -1;
    public InputControlScheme logitechX56Scheme
    {
        get
        {
            if (m_logitechX56SchemeIndex == -1) m_logitechX56SchemeIndex = asset.FindControlSchemeIndex("logitech X56");
            return asset.controlSchemes[m_logitechX56SchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
