using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideLine : MonoBehaviour
{
    // The idicator used to let the player know the direction that the ball will be shot in 
    private float rotY = 0.1f;
    public float speed = 2.0f;
    [SerializeField] private GameObject ball;
    [SerializeField] private goalController goalController_Script;

    void moveArrow()
    {
        if (this.transform.rotation.z > 0.5f) rotY = -0.1f;
        else if (this.transform.rotation.z < -0.5f) rotY = 0.1f;
        transform.RotateAround(new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z),
        new Vector3(0, rotY, 0),
        speed);
    }

    void Update()
    {
        if (goalController_Script.level > 1) speed = 4.0f;
        moveArrow();
    }
}
