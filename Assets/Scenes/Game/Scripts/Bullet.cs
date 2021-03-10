using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ShotEffect;
    SpriteRenderer SR;
    public float movementSpeedY;
    public float movementSpeedX;
    public Vector2 explodePosition;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(SR);
            Instantiate(ShotEffect, explodePosition, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Movement()
    {
        transform.position = new Vector2(transform.position.x + movementSpeedX * Time.deltaTime, transform.position.y + movementSpeedY * Time.deltaTime);
    }
}
