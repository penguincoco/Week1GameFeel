using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollide : MonoBehaviour
{
    private Animator animatorController;

    public Camera mainCam;
    public GameObject boundaryObj;

    public GameObject[] birdComponents;

    void Start() 
    {
        animatorController = this.gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D otherObj) 
    {
        if (otherObj.gameObject == boundaryObj) 
        {
            //animatorController.enabled = true;

            //mainCam.GetComponent<CameraMove>().Stop();
            // mainCam.GetComponent<CameraShake>().ShakeWrapper();
        }
    }
}
