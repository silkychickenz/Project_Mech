using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{


    [Header("Get references")]
    [SerializeField]
    private GameObject playerCam;
    [SerializeField]
    private GameObject grappleHead;                          // prefab being instanciated
    [SerializeField]
    private GameObject GrappleFrom;                          // grapple launch from position
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private GrappleHead grapplehead;                         // grapple script from grapple head that playerlaunches



    //Create Grapple
    private SpringJoint joint;                              // joint used for grapple
    private GameObject grappleHeadInstance;          
    RaycastHit hitInfo;
    private float distanceFromPoint = 0;                     //distance from player to where grapple attached to
    private bool grappleCheck = true;                        //is this grapple attempt successful?
    private Rigidbody GrappleHeadRb;
    private MechPlayerController playerController;



    [Header("Modify Grapple")]
    [SerializeField]
    private LayerMask CanGrappleTo;                          // surfaces grapple can attach to        
    [SerializeField]
    private float sphereCastRadius = 2;                      //controls difficulty while aiming grapple this is basically grapple aim assist
    [SerializeField]
    private float grappleRange = 50;                         //maximum distance a surface can be for grapple to attach    
    [SerializeField]
    private float grappleHeadLaunchforce = 80;               // force with which grapple launches from your arm    
    public bool IsGrappleActive = false;                    // store current status of grapple, active or not
    [SerializeField]
    private float grappleReleaseForce = 2;                   // when you swing and release the grapple a slight force pushes you forward and up
    [SerializeField]
    private float GrappleLength = 5;                         // how long the grapple is

  
    public void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.positionCount = 0; // how many points does linerenderer have?
        playerController = gameObject.GetComponent<MechPlayerController>();
    }
   
    
    // when button is pressed
    public void StartGrapple()
    {
        lr.positionCount = 2; // line rendered now has two points

        grappleHeadInstance = Instantiate(grappleHead, GrappleFrom.transform.position, GrappleFrom.transform.rotation); //hold grapple head prefab

        // spherecast to check if you hit a grapple surface
        if (Physics.SphereCast(playerCam.transform.position, sphereCastRadius, playerCam.transform.forward, out hitInfo, grappleRange, CanGrappleTo))
        {
            // rotate grapple head projectile by the angle between its forward vector and the vector from grappleFrom to where the grapple will hit 
            grappleHeadInstance.transform.Rotate(0, -Vector3.Angle(grappleHeadInstance.transform.forward, hitInfo.point - GrappleFrom.transform.position), 0);
            grappleCheck = true;

        }
        // instanciate the grapple projectile that is shot
      
       
        //  grapplehead = grappleHeadInstance.GetComponent<GrappleHead>();
          GrappleHeadRb = grappleHeadInstance.GetComponent<Rigidbody>();
          grappleHeadInstance.GetComponent<Rigidbody>().AddForce(grappleHeadInstance.transform.forward * grappleHeadLaunchforce, ForceMode.Impulse);
        // grappleHeadInstance.GetComponent<Rigidbody>().AddForce(GrappleFrom.transform.position+ (hitInfo.point - GrappleFrom.transform.position * grappleHeadLaunchforce), ForceMode.Impulse);
       
        Debug.DrawRay(GrappleFrom.transform.position, hitInfo.point - GrappleFrom.transform.position,Color.yellow, 200f); // zisualize grapple tregectory


    }

    
    //cancle grapple on button release
    public void CancleGrapple()
    {
        
        grappleCheck = false;   // grapple no longer active
        Destroy(grappleHeadInstance);   // remove the grapple head projectile that was created
        Destroy(GrappleHeadRb);     // remove its rigidbody reference    
        lr.positionCount = 0;   // liner renderer no long has any points
        if (!joint) // if the grapple was shot but it didnt hit anything there was no grapple joint created
        {
            return;
        }
       // Debug.Log("cancle grapple");
        IsGrappleActive = false; 
        Destroy(joint); // remove the grapple joint

        // when player releases from grapple give them some force to improve the game feel
        gameObject.GetComponent<Rigidbody>().AddForce((playerController.VelocityDirection.normalized) + gameObject.transform.up * grappleReleaseForce, ForceMode.Impulse );
    }



    public void DrawGrapple()
    {
        if (lr.positionCount == 0) return; // if grapple doesnt exist 

        // if grapple does exist
        lr.SetPosition(0, GrappleFrom.transform.position);
        lr.SetPosition(1, grappleHeadInstance.transform.position);

    }



    public void CreateGrapple()
    {
       // Debug.Log("create");
        if ( grappleCheck == true && grappleHeadInstance != null) // if projectile is instanciated and grapple ray cast returns true
        {

            if (GrappleHeadRb.isKinematic == true) // if the projectile has hit a surface successfully
            {
                // modify grapple 
                IsGrappleActive = true;
                joint = gameObject.AddComponent<SpringJoint>(); // create the actual grapple joint

                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grappleHeadInstance.transform.position;
             
                distanceFromPoint = Vector3.Distance(gameObject.transform.position, grappleHeadInstance.transform.position);

                joint.maxDistance =  GrappleLength;
                joint.minDistance = 0;
                joint.spring = 14f;
                joint.damper = 27f;
                joint.massScale = 1;

                grappleCheck = false; // make sure you can only create one grapple
            }
        }
    }



    public void RemoveObjects()
    {

        if (lr.positionCount == 2)
        {
            if (Vector3.Distance(grappleHeadInstance.transform.position, gameObject.transform.position) >= grappleRange ) // if projectile goes too farm from player
            {
                // destroy projectile and its rigidbody reference
                Destroy(grappleHeadInstance);
                Destroy(GrappleHeadRb);
                lr.positionCount = 0;

            }

            else return;
        }

    }

   
}
