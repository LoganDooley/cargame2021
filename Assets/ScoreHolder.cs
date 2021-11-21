using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHolder : MonoBehaviour
{
    public static int score;
    private int l_score;
    private int g_score;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            Destroy(this);
        }
        score = l_score + g_score;
    }

    public void UpdateLifeScore(int life_score)
    {
        l_score = life_score;
    }

    public void UpdateGrindScore(int grind_score)
    {
        g_score = grind_score;
    }
}
