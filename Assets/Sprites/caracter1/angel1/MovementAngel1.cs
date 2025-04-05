using UnityEngine;
using System;

public class AngelMovement : MonoBehaviour
{
    public bool isControlled = true;  // Control activ? (true pentru cel controlat, false pentru cel inactiv)
    public bool isPlayerOne = true;     // Pentru identificarea jucătorului (utile în modul Coop)

    float horizontalInput;
    float verticalInput;
    public float moveSpeed = 5f;       // Poate fi public pentru a-l seta din Inspector
    bool isFacingRight = true;        // presupunem că inițial caracterul se uită spre dreapta

    Rigidbody2D rb; 
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Dezactivează gravitația, deoarece personajul nostru zboară
        rb.gravityScale = 0;

        // În Singleplayer, asigură-te că Angel este controlat
        if (GlobalVariables.GAME_MODE == "Singleplayer")
        {
            isControlled = true;
        }
    }

    void Update()
    {
        // Dacă personajul nu este controlat, trecem peste procesarea inputului
        if (!isControlled)
            return;

        // Resetează inputurile
        horizontalInput = 0f;
        verticalInput = 0f;

        // Pentru Singleplayer ambele folosec aceleași taste din GlobalVariables
        if(isPlayerOne)
        {
            if(Input.GetKey(GlobalVariables.P1_LEFT)) horizontalInput -= 1f;
            if(Input.GetKey(GlobalVariables.P1_RIGHT)) horizontalInput += 1f;
            if(Input.GetKey(GlobalVariables.P1_UP)) verticalInput += 1f;
            if(Input.GetKey(GlobalVariables.P1_DOWN)) verticalInput -= 1f;
        }
        else
        {
            if(Input.GetKey(GlobalVariables.P2_LEFT)) horizontalInput -= 1f;
            if(Input.GetKey(GlobalVariables.P2_RIGHT)) horizontalInput += 1f;
            if(Input.GetKey(GlobalVariables.P2_UP)) verticalInput += 1f;
            if(Input.GetKey(GlobalVariables.P2_DOWN)) verticalInput -= 1f;
        }

        // Actualizează animațiile (dacă folosești blend tree sau alte efecte)
        animator.SetFloat("xVelocity", Math.Abs(horizontalInput * moveSpeed));
        animator.SetFloat("yVelocity", verticalInput * moveSpeed);

        FlipSprite();
    }

    void FixedUpdate()
    {
        // Dacă nu este controlat, nu actualizăm viteza
        if (!isControlled)
            return;

        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
    }

    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
