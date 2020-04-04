using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Input_Default Controls;
    public GameObject Player;
    public MechPlayerController playerController;
    
    public Grapple grapple;
    float throttle;
    Vector2 lookAround;
    public float JumpForce = 5;
    public LayerMask GroundCheck;
    public float JumpCheckDistance = 3;

    // camera rotation effect on turning
    public float maxRotation = 5;
    public float RotationSpeed = 5;
    public float SnapBackSpeed = 5;
    private void Awake()
    {
        Controls = new Input_Default();
        playerController = Player.GetComponent<MechPlayerController>();
        grapple = Player.GetComponent<Grapple>();
        Controls.Player.Throttle.performed += Throttle => throttle = (Throttle.ReadValue<float>());
        Controls.Player.LookAround.performed += LookAround => lookAround = (LookAround.ReadValue<Vector2>());
        Controls.Player.Grapple.performed += grapplectx => grapple.StartGrapple();
        Controls.Player.Grapple.canceled += grapplectx => grapple.CancleGrapple();
        Controls.Player.jump.performed += jump => playerController.Jump(JumpForce);
    }

    void Start()
    {
        playerController.LockCursor();
    }
    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        playerController.GroundCheck(GroundCheck, JumpCheckDistance);
        playerController.Movement(throttle, lookAround);
        playerController.CameraRotEffect(lookAround, maxRotation, RotationSpeed, SnapBackSpeed);
        playerController.TurnSlideReduction();
       // Debug.Log(lookAround);
        grapple.DrawGrapple();
        grapple.CreateGrapple();
        grapple.RemoveObjects();
    }

    private void OnEnable()
    {
        Controls.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }
}
