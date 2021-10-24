using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ControlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Parallax");
    }

    public void ControlsButton()
    {
        // Show Controls Menu
        MainMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        // Quit Game
        Application.Quit();
    }
}