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
    [SerializeField] private GameObject characterSelect;
    [SerializeField] private GameObject previewContainer;


    void Start()
    {
        //if (IsFirstTime())
        //    ShowFirstTimeInstructions();
        //else
        MainMenu();
    }

    private void ShowFirstTimeInstructions()
    {
        gameInstruction.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        characterSelect.SetActive(false); 
        Time.timeScale = 0f;
    }

    public bool IsFirstTime()
    {
        return PlayerPrefs.GetInt("HasPlayedBefore", 0) == 0;
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        gameLevel.SetActive(false);
        characterSelect.SetActive(false);
        previewContainer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameInstruction()
    {
        gameInstruction.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        characterSelect.SetActive(false);
        gameLevel.SetActive(false);
        previewContainer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void CharacterSelect() 
    {
        characterSelect.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        gameLevel.SetActive(false);
        previewContainer.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameLevel()
    {
        gameLevel.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        characterSelect.SetActive(false);
        previewContainer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameInstruction.SetActive(false);
        characterSelect.SetActive(false); 
        gameLevel.SetActive(false);
        previewContainer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameInstruction.SetActive(false);
        characterSelect.SetActive(false); 
        gameLevel.SetActive(false);
        previewContainer.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameInstruction.SetActive(false);
        characterSelect.SetActive(false); 
        gameLevel.SetActive(false);
        previewContainer.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameInstruction.SetActive(false);
        characterSelect.SetActive(false); 
        gameLevel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        gameInstruction.SetActive(false);
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        characterSelect.SetActive(false);
        gameLevel.SetActive(false);
        Time.timeScale = 0f;
    }
}
