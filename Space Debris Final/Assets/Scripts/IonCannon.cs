
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class IonCannon : MonoBehaviour
{
    public Rigidbody bullet;
    public AudioClip fireSound;
    private AudioSource audioSrc;
    private bool canShoot = true;

    /**
     * Allow to enable and disable the IonCannon
     */
    public void SetCanShoot(bool canShoot)
    {
        this.canShoot = canShoot;
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    /**
     * If player pushes Space key and canShoot is true, play a sound and create a new Bullet, which you shoot away from the player
     */
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canShoot)
            {
                audioSrc.PlayOneShot(fireSound);
                Rigidbody newBullet = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody;
                newBullet.velocity = transform.forward * 100.0f;
            }
        }
    }
}
