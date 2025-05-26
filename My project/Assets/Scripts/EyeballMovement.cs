using UnityEngine;
using UnityEngine.InputSystem;

public class EyeballMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float segmentLength = 1f;

    [Header("Obstacle Detection")]
    public LayerMask obstacleMask;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 segmentStart;
    private Vector3 targetPosition;
    private Vector3 bufferedDirection = Vector3.zero;
    private Vector3 lastFacingDirection = Vector3.forward;
    private bool isMoving = false;

    void Start()
    {
        transform.position = SnapToGrid(transform.position);
        segmentStart = transform.position;
        targetPosition = transform.position;
        GameManager.Instance.RegisterPlayer(gameObject);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            Quaternion targetRot = Quaternion.LookRotation(lastFacingDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 720f * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                segmentStart = transform.position;

                // 🚧 Handle buffered direction into wall
                if (bufferedDirection != Vector3.zero)
                {
                    if (!CanMove(bufferedDirection))
                    {
                        // 🔁 Stop if trying to turn into a wall
                        moveDirection = Vector3.zero;
                        lastFacingDirection = bufferedDirection;
                        bufferedDirection = Vector3.zero;
                        isMoving = false;
                        return;
                    }
                    else
                    {
                        moveDirection = bufferedDirection;
                        lastFacingDirection = moveDirection;
                        bufferedDirection = Vector3.zero;
                        targetPosition = SnapToGrid(transform.position + moveDirection);
                    }
                }
                else if (CanMove(moveDirection))
                {
                    targetPosition = SnapToGrid(transform.position + moveDirection);
                }
                else
                {
                    moveDirection = Vector3.zero;
                    isMoving = false;
                }
            }

            return;
        }

        // Rotate when idle
        if (!isMoving && lastFacingDirection != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(lastFacingDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 720f * Time.deltaTime);
        }

        // Try buffered direction if possible
        if (bufferedDirection != Vector3.zero)
        {
            if (CanMove(bufferedDirection))
            {
                moveDirection = bufferedDirection;
                lastFacingDirection = moveDirection;
                bufferedDirection = Vector3.zero;
                isMoving = true;
                targetPosition = SnapToGrid(transform.position + moveDirection);
            }
            else
            {
                // 👇 Handle wall-turn from idle too
                moveDirection = Vector3.zero;
                lastFacingDirection = bufferedDirection;
                bufferedDirection = Vector3.zero;
                isMoving = false;
            }
        }
    }

    public void OnMovement(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (input.magnitude < 0.1f) return;

        Vector2 filtered = GetFilteredDirection(input);
        Vector3 intended = new Vector3(filtered.y, 0f, -filtered.x);

        bufferedDirection = intended;
    }

    private Vector2 GetFilteredDirection(Vector2 input)
    {
        return Mathf.Abs(input.x) > Mathf.Abs(input.y)
            ? new Vector2(Mathf.Sign(input.x), 0f)
            : new Vector2(0f, Mathf.Sign(input.y));
    }

    private bool CanMove(Vector3 dir)
    {
        return !Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1f, obstacleMask);
    }

    private Vector3 SnapToGrid(Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), pos.y, Mathf.Round(pos.z));
    }
}
