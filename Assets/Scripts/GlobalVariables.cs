using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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

    // victory
    public static bool P1_victory = false;
    public static bool P2_victory = false;

    // inventory
    // Apple 1, Pitchfork 2, Flower 3
    public static int P1_inventory = 0;
    public static int P2_inventory = 0;
    public static List<string> inventory_images = new List<string> {
        "Apple",
        "Pitchfork",
        "Flower"
    };


    void Start()
    {
        // Debug.Log("Current game mode: " + GAME_MODE + "!");

    }

    public static void LoadLvl(){
        switch (GAME_MODE)
        {
            case "Coop":
                P1_UP = "w";
                P1_DOWN = "s";
                P1_LEFT = "a";
                P1_RIGHT = "d";
                P1_DROP = "";
                P1_PICK = "left ctrl";
                P1_GIVE = "left alt"; // alt
                P1_SWITCHFORM = "left shift";

                P2_UP = "up";
                P2_DOWN = "down";
                P2_LEFT = "left";
                P2_RIGHT = "right";
                P2_DROP = "";
                P2_PICK = "right ctrl";
                P2_GIVE = "right alt"; // alt
                P2_SWITCHFORM = "right shift"; 
                break;

            case "Singleplayer": 
                P1_UP = P2_UP = "w";
                P1_DOWN = P2_DOWN = "s";
                P1_LEFT = P2_LEFT = "a";
                P1_RIGHT = P2_RIGHT = "d";
                P1_DROP = P2_DROP = "";
                P1_PICK = P2_PICK = "left ctrl";
                P1_GIVE = P2_GIVE = "left alt"; // alt
                P1_SWITCHFORM = P2_SWITCHFORM = "left shift";

                SWITCH = "space";
                break;
        }

        switch (GAME_LVL)
        {
            case "Tutorial": SceneManager.LoadSceneAsync(3); break;
            case "Level1": Debug.Log("Loading Level1"); SceneManager.LoadSceneAsync(4); break;
            // case "Level2": SceneManager.LoadSceneAsync(1);
            // case "Level3": SceneManager.LoadSceneAsync(1);
            // case "Level4": SceneManager.LoadSceneAsync(1);
        }
    }
}
