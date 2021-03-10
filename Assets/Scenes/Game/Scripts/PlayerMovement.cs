using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D PlayerRigidBody;
    bool ground;
    SpriteRenderer SR;
  
    //sounds
    public AudioSource audioSource;
    public AudioClip JumpEffect;
    public AudioClip GetCoin;
    public AudioClip Death;
    public AudioClip Success;

    //Die
    private ParticleSystem ps;
    private BoxCollider2D BC2D;
  
    //player
    private Animator anm;
    private bool CanMove; 

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f * Time.deltaTime;
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        ground = true;
        anm = GetComponent<Animator>();
        CanMove = true;
        ps = GetComponent<ParticleSystem>();
        SR = GetComponent<SpriteRenderer>();
        BC2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == true)
        {
            HandleMovement(); //if can move, press buttons
        }
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            anm.SetBool("isRunning", true);
            transform.localScale = new Vector2(0.8f, transform.localScale.y);
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);

            if (ground == false)
            {
                anm.SetBool("isRunning", false);
            }

            else if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                anm.SetBool("isJumping", true);
                anm.SetBool("isRunning", false);
                PlayerRigidBody.AddForce(new Vector2(0, 500));
                ground = false;
                
                audioSource.PlayOneShot(JumpEffect);
            }
        }


        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            anm.SetBool("isRunning", true);
            transform.localScale = new Vector2(-0.8f, transform.localScale.y);
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);

            if (ground == false)
            {
                anm.SetBool("isRunning", false);
            }

            else if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                anm.SetBool("isJumping", true);
                anm.SetBool("isRunning", false);
                PlayerRigidBody.AddForce(new Vector2(0, 500));
                ground = false;

                audioSource.PlayOneShot(JumpEffect);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space) == true && ground == true)
        {
            anm.SetBool("isJumping", true);
            anm.SetBool("isRunning", false);
            PlayerRigidBody.AddForce(new Vector2(0, 500));
            ground = false;

            audioSource.PlayOneShot(JumpEffect);
        }

        else
        {
            anm.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
            anm.SetBool("isJumping", false);
        }

        if (collision.gameObject.tag == "Enemy" && collision.contacts[0].normal.y < 0.9)
        {
            PlayerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; //freeze movement
            CanMove = false;
            Destroy(SR);                                                                                                   //destroy sprite
            Destroy(BC2D);                                                                                                 //destroy boxcollider
            ps.Play();
            audioSource.PlayOneShot(Death);
            
            Invoke("Reset", 5);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(GetCoin);
            
        }

        if (collision.gameObject.tag == "Finish")
        {
            Invoke("Win", 3);
            audioSource.PlayOneShot(Success);
        }

    }

    private void Reset()
    {
        SceneManager.LoadScene("Game");
        CanMove = true;
    }

    private void Win()
    {
        SceneManager.LoadScene("Finish");
    }
}
