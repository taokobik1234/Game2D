using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    public Button[] buttons;

    void Start()
    {
        CheckLevels();
    }

    private void CheckLevels()
    {
        int unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 <= unlockedLevel)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId.ToString();
        SceneManager.LoadScene(levelName);
    }
}
