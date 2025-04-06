using UnityEngine;

public class ColiderCheckVictory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Am intalnit casa");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Inca suntem in casa");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Am plecat");
    }

}
