using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    private static string previousScene;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject settingsPanel;

    [Header("FPS Toggle")]
    public GameObject fpsCheckmark; // imaginea bifei verzi

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Stop la foc!");
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Settings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackButton()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit()
    {
        Debug.Log("QUIT called");
        Application.Quit();
    }

    public void ToggleFPS()
    {
        GlobalVariables.ShowFPSDetails = !GlobalVariables.ShowFPSDetails;
        fpsCheckmark.SetActive(GlobalVariables.ShowFPSDetails);

        if (fpsCheckmark != null)
            fpsCheckmark.SetActive(GlobalVariables.ShowFPSDetails);
    }
}
