using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    [Header("Panels")]
    public GameObject victoryPanel;

    public bool victory = false;

    void Start()
    {
        victoryPanel.SetActive(false);
    }

    public void isVictory() 
    {
        victory = true;
    }

    void Update()
    {
        if (victory)
        {
            victoryPanel.SetActive(true);
        }
    }

    public void PlayGame(){
        var nameScene = GlobalVariables.GAME_LVL;

        switch (nameScene)
        {
            case "Tutorial": SceneManager.LoadSceneAsync(3); break;
            case "Level1": SceneManager.LoadSceneAsync(4); break;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
