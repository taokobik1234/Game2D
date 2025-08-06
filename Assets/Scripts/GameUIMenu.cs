using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIMenu : MonoBehaviour
{
    [SerializeField] private GameManagerMenu gameManagerMenu;

    public void StartGame()
    {
        if (gameManagerMenu.IsFirstTime())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Intro Scene");
        }
        else
        {
            gameManagerMenu.GameLevel();
        }      
    }

    public void CharacterSelect() 
    {
        gameManagerMenu.CharacterSelect();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        gameManagerMenu.ResumeGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameInstruction()
    {
        gameManagerMenu.GameInstruction();
    }

    public void BackToMainMenu()
    {
        gameManagerMenu.BackToMainMenu();
    }
}
