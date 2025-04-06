using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public float fireCooldown = 5f;
    public float fireballSpeed = 5f;

    public float attackDuration = 1f;  // Cât timp stai în animația "attack"

    private float cooldownTimer = 0f;
    private float attackTimer = 0f;
    private bool isAttacking = false;

    private Animator animator;
    private bool facingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isAttacking)
        {
            // creștem cooldown
            cooldownTimer += Time.deltaTime;

            // stăm în idle dacă nu atacăm
            animator.Play("idle");

            // dacă am ajuns la cooldown, atacăm
            if (cooldownTimer >= fireCooldown)
            {
                Attack();
                isAttacking = true;
                attackTimer = 0f;
                cooldownTimer = 0f;
            }
        }
        else
        {
            // suntem în atac
            attackTimer += Time.deltaTime;
            animator.Play("attack");

            if (attackTimer >= attackDuration)
            {
                // revenim la starea normală (idle)
                isAttacking = false;
            }
        }
    }

    void Attack()
    {
        // instanțiem fireball-ul
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        float direction = facingRight ? -1f : 1f;
        rb.linearVelocity = new Vector2(fireballSpeed * direction, 0f);

        // flip fireball dacă e cazul
        if (!facingRight)
        {
            Vector3 scale = fireball.transform.localScale;
            scale.x *= -1f;
            fireball.transform.localScale = scale;
        }
    }

    public void SetFacingDirection(bool right)
    {
        facingRight = right;
    }
}
