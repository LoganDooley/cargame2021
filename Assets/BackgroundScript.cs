using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public GameObject[] layers;
    // next time todos: make a 2d array for layers. each time boundary is reached, 
    // move the panel at position 0 to position 1, the one at position 1 to position 
    // 2 and so on
    public Vector3[] start_pos;
    public float base_speed;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<layers.Length; i++)
        {
            start_pos[i] = layers[i].transform.position;
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i<layers.Length; i++)
        {
            layers[i].transform.position += base_speed* Vector3.left * (1f / (i + 1));
            if(layers[i].transform.position.x <= -100)
            {
                layers[i].transform.position = start_pos[i];
            }
        }
    }

    // private float length, startpos; // of sprites
    // public GameObject cam;
    // public float parallaxEffect;

    // // Start is called before the first frame update
    // void Start () {
    //     startpos = transform.position.x;
    //     length = GetComponent<SpriteRenderer>().bounds.size.x;
    // }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     // how far we've moved in world space
    //     float dist = (cam.transform.position.x * parallaxEffect);
        
    //     // move the camera
    //     cam.transform.position = new Vector3(startpos + dist, cam.transform.position.y, cam.transform.position.z);

        
    // }
}
