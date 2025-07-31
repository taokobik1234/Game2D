using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameInstruction;
    [SerializeField] private GameObject gameLevel;
    void Start()
    {
        //if (IsFirstTime())
        //{
        //    ShowFirstTimeInstructions();
        //}
        //else
        //{
        MainMenu();
        //}
    }

    private void ShowFirstTimeInstructions()
    {
        gameInstruction.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    private bool IsFirstTime()
    {
        return PlayerPrefs.GetInt("HasPlayedBefore", 0) == 0;
    }


    public void GameLevel()
    {
        gameLevel.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameInstruction.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameInstruction()
    {
        gameInstruction.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        gameInstruction.SetActive(false);
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }
}
