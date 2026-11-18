using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float flySpeed = 7f;

    Rigidbody2D rb;
    float horizontalInput;
    bool isFlying;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = 0f;
        isFlying = false;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed ||
                Keyboard.current.leftArrowKey.isPressed)
            {
                horizontalInput = -1f;
            }

            if (Keyboard.current.dKey.isPressed ||
                Keyboard.current.rightArrowKey.isPressed)
            {
                horizontalInput = 1f;
            }

            isFlying = Keyboard.current.spaceKey.isPressed;
        }
    }

    void FixedUpdate()
{
    float verticalVelocity = rb.linearVelocity.y;

    if (isFlying)
    {
        verticalVelocity = flySpeed;
    }
    else if (verticalVelocity > 0)
    {
        verticalVelocity = 0;
    }

    rb.linearVelocity = new Vector2(
        horizontalInput * moveSpeed,
        verticalVelocity
    );
}
}