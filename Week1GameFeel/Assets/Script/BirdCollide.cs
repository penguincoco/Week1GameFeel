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

    public void OnCollisionEnter2D(Collision2D otherObj) 
    {
        if (otherObj.gameObject == boundaryObj) 
        {
            mainCam.GetComponent<CameraMove>().Stop();
            mainCam.GetComponent<CameraShake>().ShakeWrapper();

            foreach (GameObject component in birdComponents)
            {
                Destroy(component.gameObject.GetComponent<Rigidbody2D>());
            }

            animatorController.enabled = true;
        }
    }
}
