using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectMode : MonoBehaviour
{
    [Header("Buttons")]
    public Button backButton;
    public Button playButton;

    [Header("Level Buttons")]
    public Button tutorialButton;
    public Button lvl1Button;
    public Button lvl2Button;
    public Button lvl3Button;
    public Button lvl4Button;

    [Header("Level Checks")]
    public Image tutorialCheck;
    public Image lvl1Check;
    public Image lvl2Check;
    public Image lvl3Check;
    public Image lvl4Check;

    [Header("Mode Buttons")]
    public Button coopButton;
    public Button singleplayerButton;

    [Header("Mode Checks")]
    public Image coopCheck;
    public Image singleplayerCheck;

    [Header("Check Sprites")]
    public Sprite greenCheck;
    public Sprite grayCheck;

    private string selectedLevel = null;
    private string selectedMode = null;

    public void Start()
    {
        playButton.interactable = false;

        coopCheck.enabled = false;
        singleplayerCheck.enabled = false;

        backButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));

        tutorialButton.onClick.AddListener(() => SelectLevel("Tutorial"));
        lvl1Button.onClick.AddListener(() => SelectLevel("Level1"));
        lvl2Button.onClick.AddListener(() => SelectLevel("Level2"));
        // lvl3Button.onClick.AddListener(() => SelectLevel("Level3"));
        // lvl4Button.onClick.AddListener(() => SelectLevel("Level4"));

        coopButton.onClick.AddListener(() => SelectGameMode("Coop"));
        singleplayerButton.onClick.AddListener(() => SelectGameMode("Singleplayer"));

        playButton.onClick.AddListener(PlayGame);
    }

    public void SelectLevel(string level)
    {
        selectedLevel = level;

        tutorialCheck.sprite = grayCheck;
        lvl1Check.sprite = grayCheck;
        lvl2Check.sprite = grayCheck;
        // lvl3Check.sprite = grayCheck;
        // lvl4Check.sprite = grayCheck;

        switch (level)
        {
            case "Tutorial": tutorialCheck.sprite = greenCheck; break;
            case "Level1": lvl1Check.sprite = greenCheck; break;
            case "Level2": lvl2Check.sprite = greenCheck; break;
            // case "Level3": lvl3Check.sprite = greenCheck; break;
            // case "Level4": lvl4Check.sprite = greenCheck; break;
        }

        CheckPlayButton();
    }

    IEnumerator FadeIn(Image image, float duration = 0.3f)
    {
        image.enabled = true;

        Color color = image.color;
        color.a = 0f;
        image.color = color;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsed / duration);
            image.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = 1f;
        image.color = color;
    }

    public void SelectGameMode(string mode)
    {
        selectedMode = mode;

        coopCheck.enabled = false;
        singleplayerCheck.enabled = false;

        coopCheck.color = new Color(1, 1, 1, 0);
        singleplayerCheck.color = new Color(1, 1, 1, 0);

        if (mode == "Coop")
            StartCoroutine(FadeIn(coopCheck));
        else if (mode == "Singleplayer")
            StartCoroutine(FadeIn(singleplayerCheck));

        CheckPlayButton();
    }

    void CheckPlayButton()
    {
        playButton.interactable = selectedLevel != null && selectedMode != null;
    }

    public void PlayGame()
    {
        Debug.Log("Play: " + selectedLevel + " - " + selectedMode);
        // PlayerPrefs.SetString("level", selectedLevel);
        // PlayerPrefs.SetString("mode", selectedMode);
        // SceneManager.LoadScene("YourLevelLoaderScene");
    }
}