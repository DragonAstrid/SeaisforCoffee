using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public string newGameScene;

    public string mainMenuScene;

    [SerializeField]
    public string creditsScene;

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {

        Application.Quit();
    }

    public void OpenCredits()
    //SceneManager.LoadScene(creditsScene);
}
