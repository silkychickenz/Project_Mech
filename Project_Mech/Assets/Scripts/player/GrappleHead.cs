using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHead : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    public LayerMask WhatCanGrappleAttachTo; // what can grapple attach to?



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }



    private void OnCollisionEnter(Collision collision)
    {
       

       if(((1 << collision.transform.gameObject.layer) & WhatCanGrappleAttachTo) != 0) // check if it collided with grappleable surface
        {
            rb.isKinematic = true;
        }
        
    }

    
}
