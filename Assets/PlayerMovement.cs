using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public LayerMask groundLayer;
    private GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.velocity = Vector2.right * speed;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = Vector2.left * speed;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = Vector2.zero;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D obstacle)
    {
       Debug.Log("hit detected");

        if (obstacle.collider.tag == "obstacle")
        {
        Debug.Log("obstacle detected");

            /* float inputX = Input.GetAxis("Horizontal");

            rb.transform.position = new Vector2(rb.position.x - 200, rb.position.y);
            */
        }
    }
}