using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    public static float speedLevel = 8f;
    // Start is called before the first frame update
    void Start()
    {
        speedLevel = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            speedLevel = 11f;
        }
    }
}
