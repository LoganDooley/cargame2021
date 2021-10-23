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
    public float pushForceSide;
    private bool grounded;
    private bool grind_grounded;
    public Animator animator;
    private bool pushing = false;
    private bool grinding = false;
    private bool running = true;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        if (!pushing){
            rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        }

        if ((grounded || grind_grounded) && !pushing)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
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
        if(obstacle.gameObject.layer == 6)
        {
            grind_grounded = true;
            animator.SetBool("Grinding", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            grind_grounded = false;
            animator.SetBool("Grinding", false);
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
        pushing = true;
        animator.SetBool("Pushing", true);
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.left * pushForceSide);
        rb.AddForce(Vector2.up * pushForceUp);
        StartCoroutine(PushDuration());
    }
    
    IEnumerator PushDuration()
    {
        yield return new WaitForSeconds(0.6f);
        pushing = false;
        animator.SetBool("Pushing", false);
    }
}