using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHead : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 stuck = Vector3.zero;
    public LayerMask collidableLayer;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "walkable" || collision.transform.gameObject.tag == "grapple")
        {
            rb.isKinematic = true;
           
        }
        
    }

    
}
