using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    public static float speedLevel = 8f;
    public AudioSource gameLoop;
    private float index = 0f;
    private bool ramping = false;
    // Start is called before the first frame update
    void Start()
    {
        speedLevel = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (ramping)
        {
            gameLoop.pitch += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            speedLevel = 11f;
            StartCoroutine(MusicRamp());
        }
    }
    IEnumerator MusicRamp()
    {
        ramping = true;
        yield return new WaitForSeconds(0.25f);
        ramping = false;
    }
    public void StopObjects()
    {
        speedLevel = 0f;
    }
}
