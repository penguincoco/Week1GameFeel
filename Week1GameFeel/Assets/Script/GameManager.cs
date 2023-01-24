using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private CloudSpawner spawner;
    public GameObject cloud;
    public GameObject bubbles;
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
            if (isMovingUp)
            {
                StopAllCoroutines();
                isMovingUp = false;
                StartCoroutine(spawner.SpawnClouds(bubbles, isMovingUp));
            }
            else
            {
                StopAllCoroutines();
                isMovingUp = true;
                StartCoroutine(spawner.SpawnClouds(cloud, isMovingUp));
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
