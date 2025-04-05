using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 15f;                 // Enemy move speed
    private bool movingRight = false;        // Current direction (start going left)

    [Header("Wall Detection")]
    public Transform wallCheck;             // Child object to detect walls
    public float wallCheckDistance = 0.2f;  // How far to check in front
    public LayerMask whatIsWall;            // Layer(s) considered "wall"

    void Update()
    {
        // Move enemy left or right
        if (movingRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 1) Raycast from wallCheck in the current moving direction
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallHit = Physics2D.Raycast(wallCheck.position, direction, wallCheckDistance, whatIsWall);

        // 2) If ray hits a wall, flip direction
        if (wallHit.collider != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;

        // Flip the sprite horizontally
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Optional: Gizmos to visualize the ray in the Scene view
    void OnDrawGizmosSelected()
    {
        if (wallCheck == null) return;
        Gizmos.color = Color.red;
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)direction * wallCheckDistance);
    }
}
