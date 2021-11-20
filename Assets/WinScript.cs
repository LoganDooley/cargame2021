using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    // public GameObject MainMenu;
    public GameObject WinMenu;

    void Start()
    {        
        WinButton();
    }

    public void ButtonButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void WinButton()
    {
        WinMenu.SetActive(true);
        // MainMenu.SetActive(false);
    }
}