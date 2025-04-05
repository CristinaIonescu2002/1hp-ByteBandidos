using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 15f;
    public float patrolDistance = 100f; // distanța în unity units (metri)
    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool goingToEnd = true;

    void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint + Vector3.right * patrolDistance * -1;
    }

    void Update()
    {
        Vector3 target = goingToEnd ? endPoint : startPoint;

        // Deplasare lină spre target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Când ajunge la destinație, inversează direcția
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            goingToEnd = !goingToEnd;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint, endPoint);
    }
}
