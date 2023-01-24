using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public float force = 4f;
    Rigidbody2D rb;
    public AudioSource MusicSource;
    [SerializeField]
    private AudioClip[] audioClips;

    public ParticleSystem particles;

    public BirdWing birdWing;

    private float bufferTimer = 0.2f;
    [SerializeField]private float timeElapsed = 0f;

    public GameObject[] wings;

    public float normalGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (particles != null)
                particles.Play();

            // if (birdWing != null)
            // {
            //     birdWing.isFlapping = true;
            // }
            foreach (GameObject wing in wings) 
            {
                if (wing.GetComponent<Animator>().enabled == false)
                    wing.GetComponent<Animator>().enabled = true;
            }

            //if isMovingUp is true
            if (GameManager.Instance.GetGameState()) 
            {
                rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
                rb.gravityScale = normalGravity;
            }
            else 
            {
                rb.AddForce(Vector3.down * force, ForceMode2D.Impulse);
                rb.gravityScale = normalGravity * -1;
            }
            
            if (MusicSource != null)
                MusicSource.Play();

            timeElapsed = 0f;
        }

        timeElapsed += Time.deltaTime;

        // if (rb.velocity.y <= 0)
        // {
        //     if (particles != null)
        //         particles.Stop();

        //     if (birdWing != null)
        //         birdWing.isFlapping = false;
        // }

        if (timeElapsed >= bufferTimer)
        {
           if (particles != null)
               particles.Stop();

        //    if (birdWing != null)
        //        birdWing.isFlapping = false;
            foreach (GameObject wing in wings) 
            {
                wing.GetComponent<Animator>().enabled = false;
            }
        }
    }
}