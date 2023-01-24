using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject circlePrefab;
    private bool isMoving = true;

    void Update() 
    {
        if (isMoving && GameManager.Instance.GetGameState()) 
            this.transform.position += Vector3.up/200f;
        else if (isMoving && GameManager.Instance.GetGameState() == false)
            this.transform.position += Vector3.down/200f;
    }

    public void Stop() 
    {
        isMoving = false;
    }

    public void Start()
    {
        isMoving = true;
    }

    IEnumerator Wait()
    {
        Debug.Log(Time.time); // time before wait
        yield return new WaitForSeconds(1);
        Debug.Log(Time.time); // time after wait
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Wait();
        Cont();
    }

    public void Cont()
    {
        Time.timeScale = 1;
    }
}
