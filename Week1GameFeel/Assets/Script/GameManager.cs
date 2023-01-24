using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
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

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            if (isMovingUp)
                isMovingUp = false;
            else 
                isMovingUp = true;
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
