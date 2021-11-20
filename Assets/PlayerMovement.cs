using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public LayerMask groundLayer;
    private GameObject obstacle;
    public float jumpForce;
    public float pushForceUp;
    public float pushForceSide;

    private bool grounded;
    public bool grind_grounded;
    private bool car_grounded;

    public Animator animator;
    private string prev_anim = "running";
    private string cur_anim = "running";

    private bool pushing = false;
    private bool grinding = false;
    private bool running = true;
    private Vector3 respawn_loc;
    public float vertical_respawn_offset = 3.5f;
    private float normal_gravity;
    private int lives = 3;
    private GameObject current_rail;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public ParticleSystem winParticles;
    private bool winning = false;
    private bool invincible = false;

    public GameObject EndPost;

    public GameObject[] layers = new GameObject[6];
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        respawn_loc = transform.position;
        normal_gravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Jump Function
        if ((grounded || grind_grounded) && !pushing)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                //Take care of grounded variables (identifiers)
                grounded = false;
                grind_grounded = false;
                //Reset the y velocity to a jump force
                rb.velocity = new Vector2(0, jumpForce);
                //TODO: Change animation control
                //animator.SetBool("Jump", true);
            }
        }

        if (!pushing)
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                if (jumpTimeCounter > 0 && isJumping)
                {
                    rb.velocity = rb.velocity = new Vector2(0, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        if(grind_grounded && !pushing)
        {
            if (Input.GetKey(KeyCode.S))
            {
                print("go down");
                //No longer grinding
                grind_grounded = false;
                StartCoroutine(DropThrough());
            }
        }

        //TODO: Replace with actual win condition
        if (Input.GetKeyDown(KeyCode.P))
        {
            Win();
        }
        if (winning)
        {
            rb.velocity = Vector2.right*10;
        }
        UpdateCurAnim();
        AnimationControl();
    }

    private void UpdateCurAnim()
    {
        if (rb.velocity.y > 0.1f)
        {
            cur_anim = "jumping up";
        }
        else if (rb.velocity.y < -0.1f )
        {
            cur_anim = "jumping down";
        }
        else if(!pushing)
        {
            if (car_grounded || grind_grounded)
            {
                cur_anim = "grinding";
            }
            else
            {
                cur_anim = "running";
            }
        }
        if(rb.velocity.x < -0.1f)
        {
            cur_anim = "pushing";
        }
    }

    private void Win()
    {
        Console.WriteLine("Inside Win");
        winning = true;
        for (int i = 0; i < layers.Length; i++)  // stop background layers
        {
            Console.WriteLine("This is C#");
            layers[i].GetComponent<BackgroundScript>().StopMoving();
        }
        audio.Stop(); // stop music

        // let player run offscreen
    }

    private void OnCollisionEnter2D(Collision2D obstacle)
    {
        //If you collide with the ground
        if(obstacle.gameObject.layer == 3)
        {
            //You are grounded
            grounded = true;
            //TODO: Change animation control
            //animator.SetBool("Jump", false);
        }
        if(obstacle.gameObject.layer == 6)
        {
            //You are grind_grounded
            grind_grounded = true;
            //TODO: Change animation control
            //animator.SetBool("Grinding", true);
            //Save rail as object
            current_rail = obstacle.gameObject;
        }
        if(obstacle.gameObject.layer == 7)
        {
            //You are car_grounded
            car_grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If you get off of a rail/grindable
        if(collision.gameObject.layer == 6)
        {
            //No longer grind_grounded
            grind_grounded = false;
            //TODO: Change animation control
            //animator.SetBool("Grinding", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If you collide with a bumper/front of car etc.
        if(collision.tag == "obstacle" && !pushing && !invincible)
        {
            StartCoroutine(PushPlayer());
        }
        else if (collision.Equals(EndPost))
        {
            Win();
        }
        else
        {
            winParticles.Emit(100);
        }
    }
    
    IEnumerator PushPlayer()
    {
        invincible = true;
        lives--;
        if(lives <= 0)
        {
            print("game over");
        }
        pushing = true;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.left * pushForceSide);
        rb.AddForce(Vector2.up * pushForceUp);
        yield return new WaitForSeconds(0.5f);
        transform.position = respawn_loc+Vector3.up*vertical_respawn_offset;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        cur_anim = "respawning";
        for(int i = 0; i<3; i++)
        {
            yield return new WaitForSeconds(0.1f);
            rb.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            rb.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        pushing = false;
        grounded = false;
        grind_grounded = false;
        rb.gravityScale = normal_gravity;
        //Respawn frames
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            rb.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            rb.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        invincible = false;
    }

    IEnumerator DropThrough()
    {
        current_rail.GetComponent<EdgeCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        current_rail.GetComponent<EdgeCollider2D>().enabled = true; ;
    }

    private void AnimationControl()
    {
        if(cur_anim != prev_anim)
        {
            prev_anim = cur_anim;
            if (cur_anim == "running")
            {
                print("run");
                animator.SetTrigger("Running");
            }
            else if (cur_anim == "jumping up")
            {
                print("jump up");
                animator.SetTrigger("JumpingUp");
            }
            else if (cur_anim == "jumping down")
            {
                print("jump down");
                animator.SetTrigger("JumpingDown");
            }
            else if(cur_anim == "grinding")
            {
                print("grinding");
                animator.SetTrigger("Grinding");
            }
            else if(cur_anim == "pushing")
            {
                print("pushing");
                animator.SetTrigger("Pushing");
            }
        }
    }
}