using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Bullet;
    public AudioClip ShotEffect;
    public AudioSource audioSource;
    public Vector2 shootLocation;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shootbullet", 1, 2.5f);
    }

    public void Shootbullet()
    {
        audioSource.PlayOneShot(ShotEffect);
        Instantiate(Bullet, shootLocation, Bullet.transform.rotation);
    }
}