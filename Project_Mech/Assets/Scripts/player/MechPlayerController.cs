using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPlayerController : MonoBehaviour
{
    //Get references ***********************************
    private Rigidbody rb;                         // rigid body of player
    public GameObject playerCam;
    public GameObject orientation;
    public Grapple grappleScript;
    public bool IsGrounded;


    // Get Parameters  ***********************************

    //movement
    public float accleration = 500;
    public float MaxSpeed = 15;
    public float RotationSpeed = 40;
    private float velocity;// hold calculated velocity and assign this to player
    public Vector3 VelocityDirection = Vector3.forward;  // hold velocities direction
    float currentRotation = 0;
    float CamRotationTracker;
    public float swingSpeedMultiplier = 0.6f; //controls the force player can apply while swinging
    public float CounterForce = 6; // force acting in opposite direction to prevent velocity exceeding hard cap
    public float VelocityHardCap = 25; //velocity above witch counter force starts acting
    private float PlayerCamVerticleAngleTracker; // tracks verticle angle of player camera
    private float CamCorrectionAmount; // when there is no input the camea is slightly tilted by this amount
    [Range(0f,1f)]
    public float ReduceSlideWhileTurning;
    public LayerMask UseSlideReductionOn;
    private float Angle;
    private bool TurnOffSlideReduction = false;
    public float ActivateSlideReductionangle = 30;
    
    
   

    //jump
    private bool jumped = false;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        grappleScript = gameObject.GetComponent<Grapple>();
        
      
    }



    public void Movement(float throttle, Vector2 LookDirection)                   // throttle is player input forward or backwards, +1 to -1
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
                velocity *= swingSpeedMultiplier;
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

    public void GroundCheck(LayerMask WhatIsGround, float JumpCheckDistance)
    {
        RaycastHit hitinfo;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.position - transform.up * JumpCheckDistance, Color.yellow);
        if (Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out hitinfo, JumpCheckDistance, WhatIsGround))
        {
            IsGrounded = true;
        }

        else
        {
            IsGrounded = false;
        }
        
    }


    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // rotate the camera in the direction player is turning
    public void CameraRotEffect(Vector2 LookDirection, float maxRotation, float RotationSpeed, float SnapBackSpeed)
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
        currentRotation += RotationSpeed * Time.deltaTime * -LookDirection.x;
        currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);  //clamp it between max in either direction
        
        // dont rotate the camera if its already rotated by max      
        if (CamRotationTracker > -maxRotation && CamRotationTracker < maxRotation)
        {
            playerCam.transform.Rotate(0, 0, currentRotation);
          
        }

    }

    public void Jump(float JumpForce)
    {
        if (IsGrounded)
        {
            Debug.Log("jumped");
            rb.AddForce(gameObject.transform.up * JumpForce, ForceMode.Impulse);
        }
    }

    public void TurnSlideReduction()
    {
        RaycastHit hitinfo;
        Debug.DrawRay(transform.position , rb.velocity.normalized * 10, Color.black);
       
        Angle = Vector3.Angle(rb.velocity, VelocityDirection);
        if (Angle > ActivateSlideReductionangle && IsGrounded && !grappleScript.IsGrappleActive && !TurnOffSlideReduction && Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out hitinfo, 5, UseSlideReductionOn))
        {
            Debug.Log("reducing");
            rb.velocity = Quaternion.Euler(0, Vector3.Angle(rb.velocity, VelocityDirection) * ReduceSlideWhileTurning, 0) * rb.velocity;
           // rb.AddForce(-rb.velocity * SlideWhileTurning);
        }
    }

}
