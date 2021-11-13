using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ControlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
        ControlsButton();
    }

    public void BackToMainMenuButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
    }

    // public void UpButton()
    // {
    //     // Show Controls Menu
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    // }

    public void ControlsButton()
    {
        // Show Controls Menu
        ControlsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    // public void ExitButton()
    // {
    //     // Quit Game
    //     Application.Quit();
    // }
}