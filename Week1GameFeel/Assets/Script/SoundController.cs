using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip clip;

    public void Start()
    {
        audioSrc = this.gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && audioSrc.isPlaying == false && GameManager.Instance.canMove == true)
        {
            audioSrc.PlayOneShot(clip);
        }
    }
}
