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

    void Update()
    {
        if (GlobalVariables.P1_victory && GlobalVariables.P2_victory)
        {
            victoryPanel.SetActive(true);
            GlobalVariables.P1_victory = false;
            GlobalVariables.P2_victory = false;
        }
    }

    public void PlayGame(){
        var nameScene = GlobalVariables.GAME_LVL;
        Debug.Log("Inca suntem in casa");

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
