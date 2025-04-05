using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    // Referințe la scripturile de mișcare ale celor două personaje
    public AngelMovement player1;
    public DevilMovement player2;

    // True dacă Player1 este activ, false dacă Player2 este activ
    private bool controllingPlayer1 = true;

    void Start()
    {
        // Dacă jocul este în modul Coop, dezactivează acest script
        if (GlobalVariables.GAME_MODE == "Coop")
        {
            this.enabled = false;
            return;
        }
    
        // Setăm inițial controlul pentru Player1
        if (player1 != null && player2 != null)
        {
            player1.isControlled = true;
            player2.isControlled = false;
            controllingPlayer1 = true;
        }
    }

    void Update()
    {
        // Aici folosim tasta definită în GlobalVariables pentru comutare
        // Asigură-te că GlobalVariables.SWITCH e setat corect (ex: "space")
        if (Input.GetKeyDown(GlobalVariables.SWITCH))
        {
            controllingPlayer1 = !controllingPlayer1;
            player1.isControlled = controllingPlayer1;
            player2.isControlled = !controllingPlayer1;
            Debug.Log("Switching control. Now controlling " + (controllingPlayer1 ? "Angel" : "Devil"));
        }
    }
}
