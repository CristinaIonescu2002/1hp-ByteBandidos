using UnityEngine;
using System;

public class AngelMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float moveSpeed = 5f;
    bool isFacingRight = true; // presupunem că inițial caracterul se uită spre dreapta

    Rigidbody2D rb; 
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Dezactivează gravitația, deoarece personajul nostru zboară
        rb.gravityScale = 0;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        FlipSprite();

        // Actualizează animațiile (dacă ai setat parametri în Animator)
        animator.SetFloat("xVelocity", Math.Abs(horizontalInput * moveSpeed));
        animator.SetFloat("yVelocity", verticalInput * moveSpeed);
    }

    void FixedUpdate()
    {
        // Setează noua viteză pe ambele axe
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }

    void FlipSprite()
    {
        // Schimbă orientarea sprite-ului în funcție de direcția de mișcare
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
