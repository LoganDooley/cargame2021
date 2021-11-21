using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            GameObject child = collision.transform.Find("DuckSound").gameObject;
            child.GetComponent<AudioSource>().Play();
        }
    }
}