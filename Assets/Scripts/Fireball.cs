using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // distruge după x secunde
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
