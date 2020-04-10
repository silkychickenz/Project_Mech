using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPlayerController : MonoBehaviour
{
    


  
    [Header("Get references")]
    [SerializeField]
    private GameObject playerCam;                        // get player FPS camera
    [SerializeField]
    private Grapple grappleScript;                       // get grapple script        
   
    private Rigidbody rb;                               // rigid body of player




    [Header("Movement")]
    [SerializeField]
    private float accleration = 500;                    // how fast mech reches top speed
    [SerializeField]
    private float MaxSpeed = 15;                        //top speed of the mech
    [SerializeField]
    private float RotationSpeed = 40;                   // how fast does the mech rotate or turn
    private float velocity;                             // hold calculated velocity and assign this to player
    public Vector3 VelocityDirection = Vector3.forward; // hold velocities direction
    [SerializeField]
    private float CounterForce = 6;                     // force acting in opposite direction to prevent velocity exceeding hard cap
    [SerializeField]
    private float VelocityHardCap = 25;                 //velocity above witch counter force starts acting



    [Header("Slide Reduction While Turning")]
    [SerializeField]
    [Range(0f, 1f)]
    private float ReduceSlideWhileTurning;              // how much slide reduction do you want?
    [SerializeField]
    private LayerMask UseSlideReductionOn;              // what surface to use slide reduction on?
    private float Angle;                                // keep track of angle bentween rigidbodys velocity and VelocityDirection
    private bool TurnOffSlideReduction = false;         // do you want to turn off slide reduction for any reason?
    [SerializeField]
    private float ActivateSlideReductionangle = 30;     // activate slide reduction if angle between rb velocity direction and velocityDirection is more than this
    private float swingSpeedMultiplier = 0.6f;          //controls the force player can apply while swinging


    
    [Header("Camera Rotation Effect")]
    private float currentRotation = 0;                  // this is how much the camera is being rotate in this frame
    private float CamRotationTracker;                   // keep track of how much the camera is currently rotated
    private float CamCorrectionAmount;                  // when there is no input the camera is slightly tilted by this amount
    private bool reduceSlide;                           // check if you are on slide reducing surface
    [SerializeField]
    private float maxRotation = 20;                     // how much do you want the camera to tile at its maximum
    [SerializeField]
    private float CamEffectRotationSpeed = 1;           // how fast should camera tilt
    [SerializeField]
    private float SnapBackSpeed = 30;                   // how fast should camera recover bask to 0 rotation fomr the tilt

   

    [Header("Ground Check")]
    [SerializeField]
    private LayerMask WhatIsGround;
    [SerializeField]
    private float GroundCheckDistance = 5;              //how far below player to check the ground
    private bool IsGrounded;



    [Header("jump")]
    [SerializeField]
    private float JumpForce = 10;                       // what force to apply when jump is pressed
    private bool jumped = false;                        // did player jump?



    // Look
    private float PlayerCamVerticleAngleTracker;        // tracks verticle angle of player camera


    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        grappleScript = gameObject.GetComponent<Grapple>();
        
      
    }


    //move player
    public void Movement(float throttle, Vector2 LookDirection)  // throttle is player input forward or backwards, +1 to -1 and look direction is input of where player is looking
    {
        //make sure player, velocity direction and camera are always rotated by the same amount in Y
        playerCam.transform.eulerAngles = new Vector3(playerCam.transform.eulerAngles.x,gameObject.transform.rotation.eulerAngles.y, playerCam.transform.eulerAngles.z);
        if (rb.velocity.magnitude > VelocityHardCap)
        {
          
          //rb.AddForce(-playerCam.transform.forward * CounterForce);           // add force opposite to where player is looking if velocity exceeds hard cap
            rb.AddForce(-rb.velocity.normalized * CounterForce);                  // add counter force opposite to velocity direction
        }
        // apply values to velocity of rigid body velocity = direction * magnitude also apply gravity
        if (rb.velocity.magnitude <= Mathf.Abs(MaxSpeed * throttle))  // throttle is how far stick is pushed. if its pushed 50% then current max speed is 50% of max speed
        {
            if (grappleScript.IsGrappleActive)
            {
                velocity *= swingSpeedMultiplier;   // playe can still throttle or apply velocity while swinging 
            }
            rb.velocity += (VelocityDirection * velocity) * Time.deltaTime;
        }
      
        Debug.DrawRay(gameObject.transform.position, VelocityDirection * 10, Color.red);  //direction of velocity
        Debug.DrawRay(gameObject.transform.position, playerCam.transform.forward * 10, Color.green);  //from center of the camera

        //modify magnitude controlled by throttle for forward and backwards
       velocity = Mathf.Clamp(velocity, -MaxSpeed * Mathf.Abs(throttle), MaxSpeed * Mathf.Abs(throttle));   // clamp speed going forward and reverse throttle is % of max speed full throttle = 1, half way = 50% etc
       velocity = (velocity + (accleration * Time.deltaTime * Mathf.Sign(throttle)));                      // acclerate in desired direction    


        // Rotate player so they can turn, horizontal rotation
       VelocityDirection = Quaternion.Euler(0, (RotationSpeed * Time.deltaTime) * LookDirection.x, 0) * VelocityDirection;   //rotate player velocity along y axis
       transform.Rotate(new Vector3(0, (RotationSpeed * Time.deltaTime) * LookDirection.x, 0));                               // rotate player game object     


        // Camera Verticle Rotation
        if (PlayerCamVerticleAngleTracker > -70 && PlayerCamVerticleAngleTracker < 70)
        {
          
            playerCam.transform.Rotate(new Vector3((RotationSpeed * Time.deltaTime) * LookDirection.y, 0, 0));
        }
       PlayerCamVerticleAngleTracker= Mathf.Clamp(PlayerCamVerticleAngleTracker, -70, 70);
       PlayerCamVerticleAngleTracker += (RotationSpeed * Time.deltaTime) * LookDirection.y;
       
        

    }


    //check for ground or other surfaces
    public void GroundCheck( )
    {
        RaycastHit hitinfo;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position - transform.up * GroundCheckDistance, Color.yellow); // ground check ray visualized
        if (Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out hitinfo, GroundCheckDistance, WhatIsGround))
        {
            IsGrounded = true;
            if (((1<<hitinfo.transform.gameObject.layer) & UseSlideReductionOn) != 0) // check layer for reduce sliding
            {
                reduceSlide = true;
            }
        }

        else
        {
            IsGrounded = false;
            reduceSlide = false;
        }
        
    }


    // lock and hide the cursor in game 
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // rotate the camera in the direction player is turning 
    public void CameraRotEffect(Vector2 LookDirection )
    {
        
        // if player is not turning then straigten the camera back to 0 rotation
        if (LookDirection.x == 0)
        {
            currentRotation = 0;    // set current rotation to 0 so next time that player turns camera dont start turning from that rotation value                        

            // if camera was turned right go left to get to 0
            if (CamRotationTracker < 0) // rotation to right
            {
                // get back to 0 and update current camera rotation as you go
                playerCam.transform.Rotate(0, 0, SnapBackSpeed * Time.deltaTime);  
                CamRotationTracker += SnapBackSpeed * Time.deltaTime;
                CamCorrectionAmount = 360 - playerCam.transform.rotation.eulerAngles.z;   // store any left over rotation there might be in the camera 
            }

            // if camera was turned left go right to get back to zero
            if (CamRotationTracker > 0) // rotation to left
            {
                // get back to 0 and update current camera rotation as you go
                playerCam.transform.Rotate(0, 0, -SnapBackSpeed * Time.deltaTime);
                CamRotationTracker += -SnapBackSpeed * Time.deltaTime;
                CamCorrectionAmount =  playerCam.transform.rotation.eulerAngles.z;       // store any left over rotation there might be in the camera 
            }
            // iron out any left over rotation
            if ( CamCorrectionAmount != 0)
            {
                if (playerCam.transform.rotation.eulerAngles.z >= 180)//rotated to right so  rotate left to correct               
                {
                    playerCam.transform.Rotate(0, 0, SnapBackSpeed * Time.deltaTime );
                 
                }

                if (playerCam.transform.rotation.eulerAngles.z < 180)//rotated to left so  rotate right to correct
                {
                    playerCam.transform.Rotate(0, 0, -SnapBackSpeed * Time.deltaTime );
                    
                }
            }

        }

        //track actual rotation of the camera and clamp it between max in either direction
        CamRotationTracker += currentRotation;
        CamRotationTracker = Mathf.Clamp(CamRotationTracker, -maxRotation, maxRotation);

        //rotation value camera is current being rotated by
        currentRotation += CamEffectRotationSpeed * Time.deltaTime * -LookDirection.x;
        currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);  //clamp it between max in either direction
        
        // dont rotate the camera if its already rotated by max      
        if (CamRotationTracker > -maxRotation && CamRotationTracker < maxRotation)
        {
            playerCam.transform.Rotate(0, 0, currentRotation);
          
        }

    }   //look direction is player input of where they are looking


    // make player jump
    public void Jump()
    {
        if (IsGrounded)
        {
            Debug.Log("jumped");
            rb.AddForce(gameObject.transform.up * JumpForce, ForceMode.Impulse);
        }
    }


    //reduces or removes sliding when player is moving and turning
    public void TurnSlideReduction()
    {
       // RaycastHit hitinfo;
        Debug.DrawRay(transform.position , rb.velocity.normalized * 10, Color.black);
       
        Angle = Vector3.Angle(rb.velocity, VelocityDirection);
        //if (Angle > ActivateSlideReductionangle && IsGrounded && !grappleScript.IsGrappleActive && !TurnOffSlideReduction && Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out hitinfo, 5, UseSlideReductionOn))
        if (Angle > ActivateSlideReductionangle && IsGrounded && !grappleScript.IsGrappleActive && !TurnOffSlideReduction && reduceSlide)
        {
            Debug.Log("reducing");
            rb.velocity = Quaternion.Euler(0, Vector3.Angle(rb.velocity, VelocityDirection) * ReduceSlideWhileTurning, 0) * rb.velocity;
           // rb.AddForce(-rb.velocity * SlideWhileTurning);
        }
    }

}
