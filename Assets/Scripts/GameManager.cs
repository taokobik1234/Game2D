using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawner;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject gameUi;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
    }

    void Update()
    {
        
    }

    public void AddEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        UpdateEnergyBar();
        if (currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpawner.SetActive(false);
        gameUi.SetActive(false);
    }

    private void UpdateEnergyBar()
    {
        if(energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
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
}
