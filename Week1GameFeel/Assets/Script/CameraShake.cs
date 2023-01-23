using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTime;
    // Transform of the GameObject you want to shake
    private Transform transform;

    // A measure of magnitude for the shake. Tweak based on your preference
    [SerializeField] private float shakeMagnitude = 0;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.GetComponent<Transform>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    }

    public void ShakeWrapper()
    {
        StartCoroutine(Shake(shakeTime));
    }

    private IEnumerator Shake(float shakeTime)
    {
        float timer = 0f;
        do
        {
            transform.position = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            timer += Time.deltaTime;
            yield return null;
        } while (timer <= shakeTime);
    }
}
