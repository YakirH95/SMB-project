using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float speed;
    Vector2 movement;
    bool CanMove;
    public float rightEdgeOfMove;
    public float leftEdgeOfMove;
    Animator DieAnm;
    public AudioClip dieSound;
    public AudioSource AS;
    BoxCollider2D BC;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1 * Time.deltaTime;
        movement = new Vector2(speed, 0);
        CanMove = true;

        BC = GetComponent<BoxCollider2D>();
        DieAnm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == true)
        {
            HandleMovement();
        }
    }  

    private void HandleMovement()
    {
        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
        if (transform.position.x >= rightEdgeOfMove)
        {
            movement = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-0.45f, 0.45f);
        }

        if (transform.position.x <= leftEdgeOfMove)
        {
            movement = new Vector2(speed, 0);
            transform.localScale = new Vector2(0.45f, 0.45f);
        }
    }

    public void StopMove()
    {
        CanMove = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y < -0.5)
        {
            StopMove();
            Destroy(BC);
            AS.PlayOneShot(dieSound);
            DieAnm.SetTrigger("Die");
            Destroy(gameObject, 1);
        }
    }
}
