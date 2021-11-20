// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// https://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class CreditsScript : MonoBehaviour
{

    public GameObject[] panels = new GameObject[3];
    public float base_speed;
    private bool move = true;

    void Start()
    {
        move = true;
    }

    void Update()
    {
        if (move)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].transform.position += Vector3.left * base_speed * Time.deltaTime;
            }

            if (panels[0].transform.position.x <= -20)
            {
                panels[0].transform.position += Vector3.right * 56;
                GameObject first_panel = panels[0];
                panels[0] = panels[1];
                panels[1] = panels[2];
                panels[2] = first_panel;
            }
        }
    }

    public void StopMoving()
    {
        move = false;
    }
}