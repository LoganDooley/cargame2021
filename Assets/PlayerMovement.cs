using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if Input.GetKeyDown(KeyCode.A)
            {
                
            }
    }
}
