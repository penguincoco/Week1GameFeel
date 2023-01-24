using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private CloudSpawner spawner;
    public GameObject cloud;
    public GameObject bubbles;
    public Camera mainCam;
    public static GameManager Instance { get { return _instance; } }  

    public bool isMovingUp = true;   

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        spawner = this.gameObject.GetComponent<CloudSpawner>();
    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            //mainCam.GetComponent<CameraMove>().Stop();
            //wait();
            mainCam.GetComponent<CameraMove>().Pause();
            mainCam.GetComponent<CameraShake>().ShakeWrapper();
            if (isMovingUp)
            {
                StopAllCoroutines();
                isMovingUp = false;
                StartCoroutine(spawner.SpawnClouds(bubbles, isMovingUp));
                // mainCam.GetComponent<CameraMove>().Cont();
                //mainCam.GetComponent<CameraMove>().Start();
            }
            else
            {
                StopAllCoroutines();
                isMovingUp = true;
                StartCoroutine(spawner.SpawnClouds(cloud, isMovingUp));
                // mainCam.GetComponent<CameraMove>().Cont();
                //mainCam.GetComponent<CameraMove>().Start();
            }
        }
    }

    public bool GetGameState() 
    {
        if (isMovingUp) 
            return true;
        else
            return false;
    }

}
