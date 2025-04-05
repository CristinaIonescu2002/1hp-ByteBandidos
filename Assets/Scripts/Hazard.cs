using UnityEngine;
using UnityEngine.SceneManagement; // Needed to reload scenes

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is tagged "Player"
        if (other.CompareTag("Player"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Alternatively, call a "Die" method on the player, show a Game Over screen, etc.
            // e.g. other.GetComponent<PlayerHealth>().TakeDamage(9999);
        }
    }
}
