using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject circlePrefab;
    private bool isMoving = true;

    void Update() 
    {
        if (isMoving) 
            this.transform.position += Vector3.up/100f;
    }

    public void Stop() 
    {
        isMoving = false;
    }
}
