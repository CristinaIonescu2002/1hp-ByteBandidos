using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform firePoint;                // Punctul de unde pornește fireball-ul
    public GameObject fireballPrefab;          // Prefab-ul de fireball
    public float fireCooldown = 5f;            // Timp între atacuri
    public float fireballSpeed = 5f;           // Viteza cu care se deplasează fireball-ul

    private float cooldownTimer = 0f;
    private Animator animator;
    private bool facingRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= fireCooldown)
        {
            Attack();
            cooldownTimer = 0f;
        }
        else
        {
            animator.Play("idle"); // numele exact al animației de idle
        }
    }

    void Attack()
    {
        animator.Play("attack"); // numele exact al animației de attack

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        float direction = facingRight ? -1f : 1f;
        rb.linearVelocity = new Vector2(fireballSpeed * direction, 0f);

        // Flip fireball dacă tragi în stânga
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
