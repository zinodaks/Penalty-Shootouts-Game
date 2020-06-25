using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //make the camera a certain offset away from the player(the ball) which makes it possible for the camers to
    //follow the ball when it's in movement
    public GameObject player ; 
    private Vector3 offset ; 
    
    void Start()
    {
        offset = transform.position - player.transform.position ;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset ; 
    }
}
