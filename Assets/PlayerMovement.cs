using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public LayerMask groundLayer;
    private GameObject obstacle;
    public float jumpForce;
    public float pushForceUp;
    public float pushVelocity;
    private bool grounded;
    public Animator animator;
    private bool pushing = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.D) && !pushing)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.A) && !pushing)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D) && !pushing)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A) && !pushing)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (grounded)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * jumpForce);
                grounded = false;
                animator.SetBool("Jump", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D obstacle)
    {
        if(obstacle.gameObject.layer == 3)
        {
            grounded = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "obstacle")
        {
            collision.transform.parent.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<BoxCollider2D>().enabled = false;
            PushPlayerBack();
        }
    }

    private void PushPlayerBack()
    {
        print("PushBack");
        pushing = true;
        rb.velocity = Vector2.left * pushVelocity;
        rb.AddForce(Vector2.up * pushForceUp);
        StartCoroutine(PushDuration());
    }
    
    IEnumerator PushDuration()
    {
        yield return new WaitForSeconds(5f);
        rb.velocity = Vector2.zero;
        pushing = false;
    }
}