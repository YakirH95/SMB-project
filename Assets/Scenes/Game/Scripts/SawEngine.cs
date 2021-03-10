using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEngine : MonoBehaviour
{
    float speed;
    Vector2 movement;
    [SerializeField] float rightEdgeOfMovement;
    [SerializeField] float leftEdgeOfMovement;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f *Time.deltaTime;
        movement = new Vector2(speed , 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 360 * Time.deltaTime));

        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
        if (transform.position.x >= rightEdgeOfMovement)
        {
            movement = new Vector2( -speed, 0);
        }

        if (transform.position.x <= leftEdgeOfMovement)
        {
            movement = new Vector2( speed , 0);
        }
    }

 
}
