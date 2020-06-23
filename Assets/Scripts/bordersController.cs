using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bordersController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private ballControll ballControll_Script;
    [SerializeField] private goalController goalController_Script;
    public GameObject borders; 
    public bool hasEntered = false;

    void Start()
    {
        ballControll_Script = ball.GetComponent<ballControll>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoccerBall"))
        {
            borders.SetActive(false);
            ballControll_Script.initializeBall2();
        }
    }
}
