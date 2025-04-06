using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public float lifeTime = 5f;
    public float delay = 0.3f; // Delay-ul la start în secunde

    void Start()
    {
        
        StartCoroutine(DelayedStart());
        Destroy(gameObject, lifeTime + delay); // distruge după x secunde
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delay);
        // Aici poți aplica, de exemplu, o viteză, sau poți activa animația fireball-ului.
        // Dacă viteză este setată din exterior, poți face aici alte acțiuni
        // De exemplu:
        // rb.velocity = new Vector2(10f, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // sau orice layer/tag
        {
            // damage logic here
            Destroy(gameObject);
        }
    }
}
