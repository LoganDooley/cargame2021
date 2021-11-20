using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    // public GameObject MainMenu;
    public GameObject LoseMenu;

    void Start()
    {        
        LoseButton();
    }

    public void BackToMainMenuButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void LoseButton()
    {
        LoseMenu.SetActive(true);
        // MainMenu.SetActive(false);
    }
}