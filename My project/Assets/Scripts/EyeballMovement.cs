using UnityEngine;
using UnityEngine.InputSystem;

public class EyeballMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float segmentLength = 1f;

    [Header("Obstacle Detection")]
    public LayerMask obstacleMask;
    public float rayLength = 0.6f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 segmentStart;
    private Vector3 bufferedDirection = Vector3.zero;
    private Vector3 lastFacingDirection = Vector3.forward; // 🧠 Always rotate to this
    private bool isMoving = false;

    void Start()
    {
        // Snap player to grid on start
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            transform.position.y,
            Mathf.Round(transform.position.z)
        );
        segmentStart = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            // ✅ Check ahead before moving
            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, moveDirection, rayLength, obstacleMask))
            {
                // Stop movement if obstacle ahead
                moveDirection = Vector3.zero;
                isMoving = false;
                return;
            }

            // Move forward
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            // Update facing direction
            if (moveDirection != Vector3.zero)
            {
                lastFacingDirection = moveDirection;
            }

            // Smooth rotation
            Quaternion targetRotation = Quaternion.LookRotation(lastFacingDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);

            // Check if we've reached a full segment
            if (Vector3.Distance(segmentStart, transform.position) >= segmentLength)
            {
                transform.position = segmentStart + moveDirection * segmentLength;
                segmentStart = transform.position;

                // Apply buffered direction (even if it’s blocked)
                if (bufferedDirection != Vector3.zero)
                {
                    moveDirection = bufferedDirection;
                    lastFacingDirection = moveDirection; // ✅ Even if blocked, rotate to it
                    bufferedDirection = Vector3.zero;
                }

                // Check if new direction is blocked
                if (Physics.Raycast(transform.position + Vector3.up * 0.5f, moveDirection, rayLength, obstacleMask))
                {
                    moveDirection = Vector3.zero;
                    isMoving = false;
                    return;
                }

                // Continue moving
                isMoving = true;
            }

            return;
        }

        // ✅ Rotate when idle
        if (lastFacingDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lastFacingDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
        }

        // Try to start moving if direction is clear
        if (bufferedDirection != Vector3.zero &&
            !Physics.Raycast(transform.position + Vector3.up * 0.5f, bufferedDirection, rayLength, obstacleMask))
        {
            moveDirection = bufferedDirection;
            lastFacingDirection = moveDirection; // ✅ Start rotating to buffered direction
            bufferedDirection = Vector3.zero;
            isMoving = true;
            segmentStart = transform.position;
        }
    }

    public void OnMovement(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (input.magnitude < 0.1f)
            return;

        Vector2 filtered = GetFilteredDirection(input);

        // 🧭 Input mapping: Up = forward, Right = right
        Vector3 intendedDirection = new Vector3(filtered.y, 0f, -filtered.x);

        bufferedDirection = intendedDirection;
        lastFacingDirection = intendedDirection; // ✅ Rotate toward this even if blocked
    }

    private Vector2 GetFilteredDirection(Vector2 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            return new Vector2(Mathf.Sign(input.x), 0f); // Horizontal
        else
            return new Vector2(0f, Mathf.Sign(input.y)); // Vertical
    }
}
