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
            particles.Play();
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            MusicSource.Play();
        }

        if (rb.velocity.y <= 0) 
        {
            particles.Stop();
        }
    }
}