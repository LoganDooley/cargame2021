using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBounce : MonoBehaviour
{
    private float default_y;
    private float sin_x;
    private float index;
    private float bounce_speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        default_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;
        float y = Mathf.Sin(bounce_speed*index);
        if(y > -0.1f)
        {
            transform.position = new Vector3(transform.position.x, default_y + 0.05f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, default_y - 0.05f, transform.position.z);
        }
    }
}
