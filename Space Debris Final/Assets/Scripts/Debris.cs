

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(SphereCollider))]
[RequireComponent (typeof(RendererFade))]

public class Debris : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;
    public AudioClip explosionSound;
    private AudioSource audioSrc;
    private float zPosition;
    private bool isDestroyed = false;
    private RendererFade renderFade;
    private bool beganFade = false;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        renderFade = GetComponent<RendererFade>();
        float rotate = Random.Range(0, 180);
        speed = Random.Range(minSpeed, maxSpeed);
        transform.Rotate(rotate, rotate, 0);
        zPosition = transform.position.z;
    }

    
   
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += transform.forward * speed * Time.deltaTime;
        newPosition.z = zPosition;
        transform.position = newPosition;
        if (isDestroyed)
        {
            if (!beganFade)
            {
                beganFade = true;
                renderFade.Fade();
            }
            if (renderFade.IsComplete())
            {
                Destroy(gameObject);
            }
        }
    }

   
    public void OnTriggerEnter(Collider collider)
    {
        if (!isDestroyed)
        {
            audioSrc.PlayOneShot(explosionSound);
            isDestroyed = true;
        }
    }
}
