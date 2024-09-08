using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject playerClone;
    [SerializeField] Vector3 cameraVelocity;
    [SerializeField] float smoothTime;

    void Start()
    {
        
    }

  
    void Update()
    {
        // transform.position=new Vector3(transform.position.x,Player.position.y,transform.position.z);
        
        if(playerClone!=null&&player.position.y>=-1)
        {
            Vector3 targetPosition = new Vector3(transform.position.x,player.position.y,transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
        }
        // else
        // transform.position = new Vector3(0,-2,transform.position.z);
    }
}
