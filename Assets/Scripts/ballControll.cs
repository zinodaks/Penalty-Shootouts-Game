using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ballControll : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject leftCamera;
    [SerializeField] private GameObject rightCamera;
    [SerializeField] private Transform arrow;
    [SerializeField] private GameObject arrowObject;
    [SerializeField] private goalController goalController_Script;
    [SerializeField] private bordersController bordersController_Script;
    [SerializeField] private Text text;
    public GameObject borders;
    private AudioSource kickSound;

    private float speed = 5.0f;
    private Vector3 euler;
    public bool canShoot = true;
    private int balls = 5;

    void cameraSwitching()
    {
        if (Input.GetKey(KeyCode.M))
        {
            mainCamera.SetActive(true);
            leftCamera.SetActive(false);
            rightCamera.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            leftCamera.SetActive(true);
            rightCamera.SetActive(false);
            mainCamera.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            rightCamera.SetActive(true);
            mainCamera.SetActive(false);
            leftCamera.SetActive(false);
        }
    }

    void moveBall()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        euler = arrow.rotation.eulerAngles;
        Quaternion rot = Quaternion.Euler(0, euler.y, 0);
        arrowObject.SetActive(false);
        transform.rotation = rot;
        GetComponent<Rigidbody>().velocity -= transform.forward * speed * 5;
        canShoot = false;
    }
    public IEnumerator handleScoring()
    {
        yield return new WaitForSeconds(1.0f);
        if (goalController_Script.hasScored == true)
        {
            goalController_Script.hasScored = false;
        }
        else
        {
            balls--;
        }
    }

    public IEnumerator initializeBall()
    {
       
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(handleScoring());
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Quaternion rot = Quaternion.Euler(0, -80.0f, 0);
            this.transform.rotation = rot;
            arrowObject.SetActive(true);
            float randomX = Random.Range(-3, 3);
            this.transform.position = new Vector3(randomX, 0.15f, 5.1f);
            canShoot = true;
            borders.SetActive(true);
        }

        public void initializeBall2()
        {
            StartCoroutine(initializeBall());
        }

        void Start()
        {
            kickSound = GetComponent<AudioSource>();
            //StartCoroutine(initializeBall());
        }

        void Update()
        {
            cameraSwitching();
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                kickSound.Play();
                moveBall();
            }
            text.text = "Balls Left: " + balls;
        }
    }
