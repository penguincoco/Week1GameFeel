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

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (particles != null)
                particles.Play();

            if (birdWing != null)
            {
                birdWing.isFlapping = true;
            }

            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            
            if (MusicSource != null)
                MusicSource.Play();

            //timeElapsed += Time.deltaTime;
        }

        if (rb.velocity.y <= 0)
        {
            if (particles != null)
                particles.Stop();

            if (birdWing != null)
                birdWing.isFlapping = false;
        }

        //if (timeElapsed >= bufferTimer)
        //{
        //    if (particles != null)
        //        particles.Stop();

        //    if (birdWing != null)
        //        birdWing.isFlapping = false;

        //    timeElapsed = 0f;
        //}
    }
}