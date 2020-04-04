using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    //private variables
    private SpringJoint joint;                            // joint used for grapple
    private GameObject grappleHeadInstance;          
    RaycastHit hitInfo;

    float distanceFromPoint = 0;                    //distance from player to where grapple attached to
    public bool grappleCheck = true;                //is this grapple attempt successful?
    private Rigidbody GrappleHeadRb;
    MechPlayerController playerController;

    //Get reference
    public GameObject playerCam;        
    public GameObject grappleHead;                  // prefab being instanciated
    public GameObject GrappleFrom;                  // grapple launch from position
    public LineRenderer lr;
    public GrappleHead grapplehead;                 // grapple script from grapple head that playerlaunches

    //Set Parameters
    public LayerMask CanGrappleTo;                          // surfaces grapple can attach to        
    public float sphereCastRadius = 2;                      //controls difficulty while aiming grapple this is basically grapple aim assist
    public float grappleRange = 50;                         //maximum distance a surface can be for grapple to attach    
    public float grappleHeadLaunchforce = 80;               // force with which grapple launches from your arm    
    public bool IsGrappleActive = false;                    // store current status of grapple, active or not
    public float grappleReleaseForce = 2;                   // when you swing and release the grapple a slight force pushes you forward and up
    public float GrappleLength = 5;                         // how long the grapple is

  
    public void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.positionCount = 0;
        playerController = gameObject.GetComponent<MechPlayerController>();
    }
   

    public void StartGrapple()
    {
        lr.positionCount = 2;

        grappleHeadInstance = Instantiate(grappleHead, GrappleFrom.transform.position, GrappleFrom.transform.rotation);

        // spherecast to check if you hit a grapple surface
        if (Physics.SphereCast(playerCam.transform.position, sphereCastRadius, playerCam.transform.forward, out hitInfo, grappleRange, CanGrappleTo))
        {
            grappleHeadInstance.transform.Rotate(0, -Vector3.Angle(grappleHeadInstance.transform.forward, hitInfo.point - GrappleFrom.transform.position), 0);
            grappleCheck = true;

        }
        // instanciate the grapple projectile that is shot
      
       
        //  grapplehead = grappleHeadInstance.GetComponent<GrappleHead>();
          GrappleHeadRb = grappleHeadInstance.GetComponent<Rigidbody>();
          grappleHeadInstance.GetComponent<Rigidbody>().AddForce(grappleHeadInstance.transform.forward * grappleHeadLaunchforce, ForceMode.Impulse);
       // grappleHeadInstance.GetComponent<Rigidbody>().AddForce(GrappleFrom.transform.position+ (hitInfo.point - GrappleFrom.transform.position * grappleHeadLaunchforce), ForceMode.Impulse);
       
        Debug.DrawRay(GrappleFrom.transform.position, hitInfo.point - GrappleFrom.transform.position,Color.yellow, 200f);


    }

    //cancle grapple on button release
    public void CancleGrapple()
    {
        
        grappleCheck = false;
        Destroy(grappleHeadInstance);
        Destroy(GrappleHeadRb);
        lr.positionCount = 0;
        if (!joint)
        {
            return;
        }
       // Debug.Log("cancle grapple");
        IsGrappleActive = false;
        Destroy(joint);
        gameObject.GetComponent<Rigidbody>().AddForce((playerController.VelocityDirection.normalized) + gameObject.transform.up * grappleReleaseForce, ForceMode.Impulse );
    }

    public void DrawGrapple()
    {
        if (lr.positionCount == 0) return;


        lr.SetPosition(0, GrappleFrom.transform.position);
      
        lr.SetPosition(1, grappleHeadInstance.transform.position);

        
       
       // Debug.DrawRay(GrappleFrom.transform.position, lr.GetPosition(9) - lr.GetPosition(0)); //allign points along this

       

    }

    public void CreateGrapple()
    {
       // Debug.Log("create");
        if ( grappleCheck == true && grappleHeadInstance != null)
        {

            if (GrappleHeadRb.isKinematic == true)
            {
                //Debug.Log("joint made");
                IsGrappleActive = true;
                joint = gameObject.AddComponent<SpringJoint>();

                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grappleHeadInstance.transform.position;
               // Debug.Log(joint.connectedAnchor);


                distanceFromPoint = Vector3.Distance(gameObject.transform.position, grappleHeadInstance.transform.position);

                joint.maxDistance =  GrappleLength;
                joint.minDistance = 0;


                joint.spring = 14f;
                joint.damper = 27f;
                joint.massScale = 1;

                grappleCheck = false;
            }
        }
    }

    public void RemoveObjects()
    {

        if (lr.positionCount == 2)
        {
            if (Vector3.Distance(grappleHeadInstance.transform.position, gameObject.transform.position) >= grappleRange + 5)
            {
                Destroy(grappleHeadInstance);
                Destroy(GrappleHeadRb);
                lr.positionCount = 0;

            }

            else return;
        }

    }

   
}
