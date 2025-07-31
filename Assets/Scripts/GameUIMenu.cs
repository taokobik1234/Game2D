using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class GameUIMenu : MonoBehaviour
{
    [SerializeField] private GameManagerMenu gameManagerMenu;
    public void StartGame()
    {
        gameManagerMenu.GameLevel();
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
