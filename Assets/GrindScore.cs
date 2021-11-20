using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindScore : MonoBehaviour
{
    public float GrindNum = 0;
    public GameObject player;
    private bool grinding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grinding = player.gameObject.GetComponent<PlayerMovement>().grind_grounded;
        if (grinding == true)
        {
            GrindNum = GrindNum + 1;
        }
    }
}
