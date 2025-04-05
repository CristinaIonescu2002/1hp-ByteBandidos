using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    public static string GAME_MODE = "";
    public static string GAME_LVL = "";
    
    // player 1
    public static string P1_UP = "";
    public static string P1_DOWN = "";
    public static string P1_LEFT = "";
    public static string P1_RIGHT = "";

    public static string P1_DROP = "";
    public static string P1_PICK = "";

    // give the item holt to the other player
    public static string P1_GIVE = "";

    // player 2
    public static string P2_UP = "";
    public static string P2_DOWN = "";
    public static string P2_LEFT = "";
    public static string P2_RIGHT = "";

    public static string P2_DROP = "";
    public static string P2_PICK = "";
    public static string P2_GIVE = "";

    // switch characters
    public static string SWITCH = "";

    // switch forms
    public static string P1_SWITCHFORM = "";
    public static string P2_SWITCHFORM = "";



    // Option menu
    public static bool ShowFPSDetails = true;

    void Start()
    {
        Debug.Log("Current game mode: " + GAME_MODE + "!");

    }

    public static void LoadLvl(){
        switch (GAME_MODE)
        {
            case "Coop": 
                P1_UP = "w";
                P1_DOWN = "s";
                P1_LEFT = "a";
                P1_RIGHT = "d";
                P1_DROP = ""; // ma gandeam la left shift
                P1_PICK = ""; // ma gandeam la left shift
                P1_GIVE = ""; // ma gandeam la left ctrl
                P1_SWITCHFORM = "left shift"; // ma gandeam la left shift

                P2_UP = "up"; // sageata sus
                P2_DOWN = "down"; // sageata jos
                P2_LEFT = "left"; // sageata stanga
                P2_RIGHT = "right"; // sageata dreapta
                P2_DROP = ""; // ma gandeam la right shift
                P2_PICK = ""; // ma gandeam la right shift
                P2_GIVE = ""; // ma gandeam la right ctrl
                P2_SWITCHFORM = "right shift"; // ma gandeam la right shift
                break;

            case "Singleplayer": 
                P1_UP = P2_UP = "w";
                P1_DOWN = P2_DOWN = "s";
                P1_LEFT = P2_LEFT = "a";
                P1_RIGHT = P2_RIGHT = "d";
                P1_DROP = P2_DROP = ""; // ma gandeam la left shift
                P1_PICK = P2_PICK = ""; // ma gandeam la left shift
                P1_GIVE = P2_GIVE = ""; // ma gandeam la left ctrl
                P1_SWITCHFORM = P2_SWITCHFORM = "left shift"; // ma gandeam la left shift

                SWITCH = "space";
                break;
        }

        switch (GAME_LVL)
        {
            case "Tutorial": SceneManager.LoadSceneAsync(4); break;
            case "Level1": SceneManager.LoadSceneAsync(5); break;
            // case "Level2": SceneManager.LoadSceneAsync(1);
            // case "Level3": SceneManager.LoadSceneAsync(1);
            // case "Level4": SceneManager.LoadSceneAsync(1);
        }
    }
}
