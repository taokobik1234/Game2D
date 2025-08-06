using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject introPanel;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Image backgroundImage;

    [Header("Story Content")]
    [SerializeField] private string[] storyLines;
    [SerializeField] private Sprite[] backgroundImages;

    private int currentLine = 0;
    private string nextScene = "";

    void Start()
    {
        // Check which intro to show based on scene or PlayerPrefs
        SetupIntro();
        ShowIntro();
    }

    void SetupIntro()
    {
        // Game Start Intro
        if (PlayerPrefs.GetInt("GameStarted", 0) == 0)
        {
            SetupGameStartIntro();
        }
        // Level 2 Intro  
        else if (PlayerPrefs.GetInt("Level1Complete", 0) == 1 && PlayerPrefs.GetInt("Level2Started", 0) == 0)
        {
            SetupLevel2Intro();
        }
        // Game Ending
        else if (PlayerPrefs.GetInt("Level2Complete", 0) == 1)
        {
            SetupGameEndingIntro();
        }
        else
        {
            // Skip intro, go to game
            SceneManager.LoadScene("Level 1");
        }
    }

    void SetupGameStartIntro()
    {
        storyLines = new string[]
        {
            "The year is 2024. A military experiment has gone wrong...",
            "The Genesis compound has turned most humans into zombies.",
            "You are Agent Phoenix - immune to the infection.",
            "Your mission: Find the source and stop the outbreak.",
            "Navigate to the desert facility and collect energy cores.",
            "Good luck, Agent. Humanity depends on you."
        };
        nextScene = "Level 1";
        PlayerPrefs.SetInt("GameStarted", 0);
        PlayerPrefs.SetInt("HasPlayedBefore", 1);
    }

    void SetupLevel2Intro()
    {
        storyLines = new string[]
        {
            "Desert facility secured. Energy cores collected.",
            "Intel points to a forest research lab.",
            "Scientists were working on an antidote before the outbreak.",
            "This is your last chance to find the cure.",
            "Proceed to the forest laboratory.",
            "The final mission begins now."
        };
        nextScene = "Level 2";
        PlayerPrefs.SetInt("Level2Started", 1);
    }

    void SetupGameEndingIntro()
    {
        storyLines = new string[]
        {
            "Mission Complete! Antidote secured.",
            "The serum flows through your veins.",
            "You have the cure to save humanity.",
            "The zombie outbreak can finally be stopped.",
            "Agent Phoenix - Mission Accomplished.",
            "Thank you for playing!"
        };
        nextScene = "Main Menu"; // or wherever you want to go
    }

    void ShowIntro()
    {
        introPanel.SetActive(true);
        currentLine = 0;
        DisplayCurrentLine();

        // Setup continue button
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(NextLine);
    }

    void DisplayCurrentLine()
    {
        if (currentLine < storyLines.Length)
        {
            StartCoroutine(TypeText(storyLines[currentLine]));
        }
    }

    IEnumerator TypeText(string text)
    {
        storyText.text = "";
        foreach (char c in text)
        {
            storyText.text += c;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine < storyLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            // Story finished, go to next scene
            FinishIntro();
        }
    }

    void FinishIntro()
    {
        introPanel.SetActive(false);

        if (nextScene == "Main Menu")
        {
            // Game completed, reset progress if desired
            // PlayerPrefs.DeleteKey("GameStarted");
            // PlayerPrefs.DeleteKey("Level1Complete");  
            // PlayerPrefs.DeleteKey("Level2Complete");
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    // Call this when Level 1 is completed
    public static void CompleteLevel1()
    {
        PlayerPrefs.SetInt("Level1Complete", 1);
        SceneManager.LoadScene("IntroScene"); // Load this intro scene again
    }

    // Call this when Level 2 is completed  
    public static void CompleteLevel2()
    {
        PlayerPrefs.SetInt("Level2Complete", 1);
        SceneManager.LoadScene("IntroScene"); // Load this intro scene again
    }
}
