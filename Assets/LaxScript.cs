using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaxScript : MonoBehaviour
{
    public GameObject[] layers;
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
            if(layers[i].transform.position.x <= -8.9)
            {
                print(start_pos.Length);
                layers[i].transform.position = start_pos[i];
;            }
        }
    }
}
