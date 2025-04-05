using UnityEngine;
using System;

public class DevilMovement : MonoBehaviour
{
    public bool isControlled = false;      // True dacă acest personaj este controlat
    public bool isPlayerOne = false;      // Pentru a diferenția inputul (folosim tastele din GlobalVariables)

    public float moveSpeed = 5f;          // Viteza de deplasare orizontală
    public float jumpForce = 10f;         // Forța de săritură

    float horizontalInput;
    bool jumpInput;
    bool isFacingRight = true;          

    public Transform groundCheck;         // Un obiect gol plasat la nivelul picioarelor (asignează în Inspector)
    public float groundCheckRadius = 0.2f;  // Raza cercului pentru verificarea solului
    public LayerMask groundLayer;         // Layer-ul pe care se găsește solul

    Rigidbody2D rb;
    Animator animator;

    // Variabilă internă pentru a urmări starea de săritură
    bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Pentru Devil, gravitația rămâne activă
        rb.gravityScale = 1f;
        // În Singleplayer, Devil pornește necontrolat
        if (GlobalVariables.GAME_MODE == "Singleplayer")
        {
            isControlled = false;
        }
    }

    void Update()
    {
        if (!isControlled)
            return;

        // Resetăm inputurile
        horizontalInput = 0f;
        jumpInput = false;

        // Citește inputurile în funcție de jucător
        if (!isPlayerOne)
        {
            if (Input.GetKey(GlobalVariables.P2_LEFT))
                horizontalInput = -1f;
            if (Input.GetKey(GlobalVariables.P2_RIGHT))
                horizontalInput = 1f;
            if (Input.GetKeyDown(GlobalVariables.P2_UP))
                {jumpInput = true; Debug.Log("Jumping!");} // Debug pentru a verifica săritura
                
        }
        else
        {
            // Dacă, din orice motiv, Devil ar folosi tastele P1 (nu se va folosi în mod normal)
            if (Input.GetKey(GlobalVariables.P1_LEFT)) horizontalInput = -1f;
            if (Input.GetKey(GlobalVariables.P1_RIGHT)) horizontalInput = 1f;
            if (Input.GetKeyDown(GlobalVariables.P1_UP)) {jumpInput = true; Debug.Log("Jumping!");} // Debug pentru a verifica săritura
        }
        


        // Verifică dacă personajul este pe sol
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Dacă avem input de săritură și suntem pe sol, efectuăm săritura
        if (jumpInput && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
        }

        // Dacă personajul este pe sol, setăm isJumping la false
        if (isGrounded)
        {
            isJumping = false;
        }

        // Actualizează parametrii pentru Animator
        animator.SetFloat("xVelocity", Mathf.Abs(horizontalInput * moveSpeed));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isJumping", isJumping);

        FlipSprite();
    }

    void FixedUpdate()
    {
        if (!isControlled)
            return;

        // Mișcarea orizontală (gravitația se ocupă de axa Y)
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    // Opțional: desenează vizual cercul de verificare a solului în Editor
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
