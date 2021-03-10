using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpykeEngine : MonoBehaviour
{
    Vector2 movement;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        movement = new Vector2(0, speed *Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + movement.y);
        if (transform.position.y >= 25)
        {
            movement = new Vector2(0, -speed * Time.deltaTime);
        }

        if (transform.position.y <= 16)
        {
            movement = new Vector2(0, speed * Time.deltaTime);
        }
    }

 
}
