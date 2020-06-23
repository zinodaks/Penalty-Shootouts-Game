using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalController : MonoBehaviour
{
    private AudioSource goalSound;
    private int score = 0;
    public int level = 0;
    

    public bool hasScored = false;

    [SerializeField] private GameObject ball;
    [SerializeField] private ballControll ballControl_Script;

    [SerializeField] private Text scoretext;
    [SerializeField] private Text leveltext;

    void Start()
    {
        goalSound = GetComponent<AudioSource>();
        ballControl_Script = ball.GetComponent<ballControll>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        scoretext.text = "Score: " + score;
        leveltext.text = "Level: " + level;
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasScored == false)
        {
            hasScored = true;
            goalSound.Play();
            score++;
            if (score % 3 == 0) level++;
        }
    }
}
