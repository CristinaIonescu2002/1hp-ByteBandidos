using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void Options(){
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT called");
        Application.Quit();
    }
}
