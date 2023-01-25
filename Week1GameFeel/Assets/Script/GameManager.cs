using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private CloudSpawner spawner;
    public GameObject cloud;
    public GameObject bubbles;
    public Camera mainCam;
    public static GameManager Instance { get { return _instance; } }  

    public GameObject[] birdComponents;
    private float gravityVal;
    public CameraMove cameraScript;

    public TextMeshProUGUI counterTxt;
    public GameObject blackImg;

    public bool canMove = false;

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
        gravityVal = birdComponents[0].gameObject.GetComponent<Rigidbody2D>().gravityScale;
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame() 
    {
        canMove = false;

        foreach(GameObject component in birdComponents) 
        {
            component.GetComponent<Rigidbody2D>().gravityScale = 0f;
            component.GetComponent<BirdMove>().enabled = false;
        }

        cameraScript.enabled = false;

        float countdownTimer = 3f;

        for (int i = 3; i > 0; i--)
        {
            counterTxt.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        counterTxt.text = "Go!";

        yield return new WaitForSeconds(1f);
        
        canMove = true;
        blackImg.SetActive(false);
        counterTxt.text = "";

        foreach(GameObject component in birdComponents) 
        {
            component.GetComponent<Rigidbody2D>().gravityScale = gravityVal;
            component.GetComponent<BirdMove>().enabled = true;
        }

        cameraScript.enabled = true;
    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.R)) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            //mainCam.GetComponent<CameraMove>().Stop();
            //wait();
            //mainCam.GetComponent<CameraMove>().Pause();
            //mainCam.GetComponent<CameraShake>().ShakeWrapper();
            if (isMovingUp)
            {
                StopAllCoroutines();
                mainCam.GetComponent<CameraMove>().changeColorOne();
                isMovingUp = false;
                StartCoroutine(spawner.SpawnClouds(bubbles, isMovingUp));
                // mainCam.GetComponent<CameraMove>().Cont();
                //mainCam.GetComponent<CameraMove>().Start();
            }
            else
            {
                StopAllCoroutines();
                mainCam.GetComponent<CameraMove>().changeColorTwo();
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
