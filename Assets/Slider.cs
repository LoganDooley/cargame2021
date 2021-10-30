using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public UnityEngine.UI.Slider progress_bar;
    public GameObject level_bar;
    private float start_x;
    private float final_x = -23.83f;
    // Start is called before the first frame update
    void Start()
    {
        level_bar.transform.position = new Vector3(23.83f, level_bar.transform.position.y, level_bar.transform.position.z);
        start_x = level_bar.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (level_bar.transform.position.x - start_x) / (final_x - start_x);
        progress_bar.value = progress;
    }
}