using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float patrolDistance = 3f;

    Rigidbody2D rb;
    float startingPosition;
    int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        float distance = transform.position.x - startingPosition;

        if (distance >= patrolDistance)
        {
            direction = -1;
        }
        else if (distance <= -patrolDistance)
        {
            direction = 1;
        }

        rb.linearVelocity = new Vector2(
            direction * moveSpeed,
            rb.linearVelocity.y
        );
    }
}
