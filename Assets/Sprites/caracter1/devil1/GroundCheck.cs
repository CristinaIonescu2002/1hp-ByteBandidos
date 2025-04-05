using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("Ground Check Settings")]
    public Transform groundCheck;      // Obiectul de tip GroundCheck creat la pasul 1
    public float groundCheckRadius = 0.2f;  // Raza cercului pentru verificare (ajustează după necesitate)
    public LayerMask groundLayer;      // Layer-ul la care aparține solul (selectează "Ground" în Inspector)

    // Variabila pentru a verifica dacă personajul este pe sol
    public bool isGrounded;

    void Update()
    {
        // Folosim OverlapCircle pentru a detecta dacă există vreun collider pe layer-ul "Ground" în jurul poziției groundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }

    // Metodă opțională pentru a desena cercul în Editor (ajută la vizualizare)
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
