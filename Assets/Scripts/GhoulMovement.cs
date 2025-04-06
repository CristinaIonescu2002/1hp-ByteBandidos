using UnityEngine;

public class GhoulMovement : MonoBehaviour
{
    public float moveSpeed = 10f;  // Viteza de mișcare
    public float leftLimit = -5f; // Punctul stâng la care se întoarce
    public float rightLimit = 5f; // Punctul drept la care se întoarce

    private Rigidbody2D rb;
    private int direction = 1; // 1 = spre dreapta, -1 = spre stânga
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Asigură-te că inamicul privește spre direcția inițială
        if(spriteRenderer != null)
        {
            // Dacă direcția e 1 (dreapta), nu flip; dacă e -1, flip.
            spriteRenderer.flipX = (direction > 0);
        }
    }

    void Update()
    {
        // Mișcarea inamicului
        rb.linearVelocity = new Vector2(moveSpeed * direction, rb.linearVelocity.y);

        // Verifică dacă a ajuns la limite și inversează direcția
        if (transform.position.x >= rightLimit && direction > 0)
        {
            direction = -1;
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = false; // Flip pentru a privi spre stânga
            }
        }
        else if (transform.position.x <= leftLimit && direction < 0)
        {
            direction = 1;
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = true; // Flip pentru a privi spre dreapta
            }
        }
    }
}
