using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollide : MonoBehaviour
{
    public Camera mainCam;
    public GameObject boundaryObj;

    public void OnCollisionEnter2D(Collision2D otherObj) 
    {
        if (otherObj.gameObject == boundaryObj) 
        {
            mainCam.GetComponent<CameraMove>().Stop();
            mainCam.GetComponent<CameraShake>().ShakeWrapper();

            Destroy(this.gameObject.GetComponent<BirdMove>());
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
        }
    }
}
