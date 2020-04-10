using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Input_Default Controls;      // input asset
    [SerializeField]
    private GameObject Player;
    private MechPlayerController playerController;
    
    private Grapple grapple;

    //store movement input
    private float throttle;
    private Vector2 lookAround;
    
    

    // camera rotation effect on turning
 
    private void Awake()
    {
        // get reference
        Controls = new Input_Default();
        playerController = Player.GetComponent<MechPlayerController>();
        grapple = Player.GetComponent<Grapple>();

        // get input
        Controls.Player.Throttle.performed += Throttle => throttle = (Throttle.ReadValue<float>());
        Controls.Player.LookAround.performed += LookAround => lookAround = (LookAround.ReadValue<Vector2>());
        Controls.Player.Grapple.performed += grapplectx => grapple.StartGrapple();
        Controls.Player.Grapple.canceled += grapplectx => grapple.CancleGrapple();
        Controls.Player.jump.performed += jump => playerController.Jump();
    }

    void Start()
    {
        playerController.LockCursor();
    }
   

    void Update()
    {
        // call methods
        playerController.GroundCheck();
        playerController.Movement(throttle, lookAround);
        playerController.CameraRotEffect(lookAround);
        playerController.TurnSlideReduction();
      
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
