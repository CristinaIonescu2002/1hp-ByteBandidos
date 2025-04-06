using UnityEngine;

public class ColiderCheckVictory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("A intrat: " + this.gameObject.name);
        // Debug.Log("A intrat: " + collision.gameObject.name);

        if (collision.gameObject.name == "SafeSpaceVictory") {
            if (this.gameObject.name.Contains("Blue")){
                GlobalVariables.P2_victory = true;
            }

            if (this.gameObject.name.Contains("Purple")){
                GlobalVariables.P1_victory = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Apple")) {
            if (this.gameObject.name.Contains("Blue") && Input.GetKey(GlobalVariables.P1_PICK)){
                GlobalVariables.P1_inventory = 1;
                Destroy(collision.gameObject);
            }

            if (this.gameObject.name.Contains("Purple") && Input.GetKey(GlobalVariables.P2_PICK)){
                GlobalVariables.P2_inventory = 1;
                Destroy(collision.gameObject);
            }

        } else if (collision.gameObject.name.Contains("Pitchfork")) {
            if (this.gameObject.name.Contains("Blue") && Input.GetKey(GlobalVariables.P1_PICK)){
                GlobalVariables.P1_inventory = 2;
                Destroy(collision.gameObject);
            }

            if (this.gameObject.name.Contains("Purple") && Input.GetKey(GlobalVariables.P2_PICK)){
                GlobalVariables.P2_inventory = 2;
                Destroy(collision.gameObject);
            }
        } else if (collision.gameObject.name.Contains("Flower")) {
            if (this.gameObject.name.Contains("Blue") && Input.GetKey(GlobalVariables.P1_PICK)){
                GlobalVariables.P1_inventory = 3;
                Destroy(collision.gameObject);
            }

            if (this.gameObject.name.Contains("Purple") && Input.GetKey(GlobalVariables.P2_PICK)){
                GlobalVariables.P2_inventory = 3;
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("Am plecat");
        if (collision.gameObject.name == "SafeSpaceVictory") {
            if (this.gameObject.name.Contains("Blue")){
                GlobalVariables.P2_victory = false;
            }

            if (this.gameObject.name.Contains("Purple")){
                GlobalVariables.P1_victory = false;
            }
        }
    }

}
