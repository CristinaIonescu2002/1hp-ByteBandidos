using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    private static string previousScene;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     if (SceneManager.GetActiveScene().buildIndex != 0)
        //     {
        //         Debug.Log("Stop la foc!");
        //         previousScene = SceneManager.GetActiveScene().buildIndex;
        //         Time.timeScale = 0f;
        //         SceneManager.LoadScene("Options");
        //     }
        // }
    }

    public static void ResumeGame()
    {
        // Time.timeScale = 1f;
        // if (!string.IsNullOrEmpty(previousScene))
        // {
        //     SceneManager.LoadScene(previousScene);
        // }
    }
}
