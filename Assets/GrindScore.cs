using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrindScore : MonoBehaviour
{
    public float GrindNum = 0;
    public GameObject player;
    public GameObject score;
    private bool grinding;
    public Image grindBar;
    private float g_scale_x;
    private float g_scale_y;
    private float index = 0f;
    private float pulse_speed = 10f;
    public GameObject scoreHolder;

    // Start is called before the first frame update
    void Start()
    {
        g_scale_x = grindBar.rectTransform.localScale.x;
        g_scale_y = grindBar.rectTransform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;
        grinding = player.gameObject.GetComponent<PlayerMovement>().grind_grounded;
        if (grinding == true)
        {
            GrindNum = GrindNum + 1;
            grindBar.transform.localScale = new Vector3(1f + 0.2f*Mathf.Abs(Mathf.Sin(pulse_speed*index)), 1f + 0.2f*Mathf.Abs(Mathf.Sin(pulse_speed * index)), 1f);
        }
        else
        {
            grindBar.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (GrindNum == 0f)
        {
            score.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "0";
        }
        else
        {
            score.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = (GrindNum / 10).ToString("#");
        }
        scoreHolder.GetComponent<ScoreHolder>().UpdateGrindScore((int)(GrindNum/10));
    }
}
