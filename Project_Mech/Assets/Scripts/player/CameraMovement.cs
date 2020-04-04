using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
   
    void Update()
    {
        transform.position = Player.position;
        
       // Debug.Log(transform.eulerAngles.y);
    }
}
